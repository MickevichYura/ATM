using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ATM;
using ATM.Language;
using ATM.Reader;
using ATM.Writer;
using log4net;
using log4net.Config;

namespace AtmConsoleUI
{

    public static class Program
    {
        public static readonly ILog Log = LogManager.GetLogger(typeof (Program));

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

            CashMachine atm = new CashMachine();
            string extension = "Txt";
            ICassetteReader<List<Cassette>> cassetteReader;
            cassetteReader = ReadersCollection.GetReader(extension);
            List<Cassette> cassettes = cassetteReader.LoadCassettes(ConfigurationManager.AppSettings["PathToMoney" + extension]);
            atm.InsertCassettes(cassettes);

            while (atm.TotalMoney != 0)
            {
                Console.WriteLine(atm.TotalMoney);
                var readLine = Console.ReadLine();

                decimal requestedSum;
                if (!decimal.TryParse(readLine, out requestedSum) || requestedSum <= decimal.Zero)
                {
                    if (readLine.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }

                    Console.WriteLine(languagePack.WrongInput);
                    continue;
                }

                var money = atm.WithdrawMoney(requestedSum);
                switch (atm.CurrentState)
                {
                    case AtmState.Ok:
                    {
                        Console.WriteLine(MoneyConverter.ConvertToString(money));
                        break;
                    }
                    default:
                        Console.WriteLine(statesDictionary[atm.CurrentState]);
                        break;
                }
            }

            List<Cassette> newCassettes =
                atm.AllMoney.Banknotes.Select(cassette => new Cassette(cassette.Key, cassette.Value)).ToList();

            foreach (var cassetteWriter in WritersCollection.CassetteWriters)
            {
                cassetteWriter.Value.WriteCassettes(newCassettes, ConfigurationManager.AppSettings["PathToMoney" + cassetteWriter.Key]);
            }
        }
       
    }
}
