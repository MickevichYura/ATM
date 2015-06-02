using System;
using System.Collections.Generic;
using System.Configuration;
using ATM;
using ATM.Language;
using log4net;
using log4net.Config;

namespace AtmConsoleUI
{

    public static class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));

        private static CashMachine _atm;

        private static void Main()
        {
            XmlConfigurator.Configure();
            Log.Debug("start");
            ILanguage languagePack = new LanguagePack("en-US");
           // ILanguage languagePack = new LanguagePack("ru-RU");

            Dictionary<AtmState, string> statesDictionary = new Dictionary<AtmState, string>() 
            { 
                {AtmState.Ok, languagePack.Ok},
                {AtmState.NotEnoughMoney, languagePack.NotEnoughMoney}, 
                {AtmState.ImpossibleToCollectMoney, languagePack.ImpossibleToCollectMoney},
                {AtmState.TooManyBanknotes, languagePack.TooManyBanknotes}
            };

            _atm = CashMachine.Deserialize(ConfigurationManager.AppSettings["SerializationFile"]) ?? new CashMachine();

            CommandPerformer commandPerformer = new CommandPerformer(ref _atm, ref languagePack);

            while (true)
            {
                Console.WriteLine(_atm.TotalMoney);
                var readLine = Console.ReadLine();

                decimal requestedSum;

                if (decimal.TryParse(readLine, out requestedSum) && requestedSum > decimal.Zero)
                {
                    var money = _atm.WithdrawMoney(requestedSum);
                    switch (_atm.CurrentState)
                    {
                        case AtmState.Ok:
                            {
                                Console.WriteLine(MoneyConverter.ConvertToString(money));
                                break;
                            }
                        default:
                            Console.WriteLine(statesDictionary[_atm.CurrentState]);
                            break;
                    }
                    continue;
                }
                bool isCommand = readLine != null && commandPerformer.TryPerform(readLine.Trim().ToLower());

                if (!isCommand)
                {
                    Console.WriteLine(languagePack.WrongInput);
                }

            }
        }
       
    }
}
