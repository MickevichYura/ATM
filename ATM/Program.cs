using System;
using System.Collections.Generic;
using System.Configuration;
using ATM.Reader;
using ATM.Writer;
using log4net;

namespace ATM
{
    public static class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CashMachine));

        private static void Main()
        {
            Log.Info(DateTime.Now);
            var atm = new CashMachine();
            ICassetteReader<List<Cassette>> cassetteReader = new TxtCassetteReader();
            List<Cassette> cassettes = cassetteReader.ReadCassettes(ConfigurationManager.AppSettings["PathToMoneyTxt"]);

            cassetteReader = new XmlCassetteReader<List<Cassette>>();
            cassettes = cassetteReader.ReadCassettes(ConfigurationManager.AppSettings["PathToMoneyXml"]);

            cassetteReader = new JsonCassetteReader<List<Cassette>>();
            cassettes = cassetteReader.ReadCassettes(ConfigurationManager.AppSettings["PathToMoneyJson"]);

            cassetteReader = new CsvCassetteReader();
            cassettes = cassetteReader.ReadCassettes(ConfigurationManager.AppSettings["PathToMoneyCsv"]);

            atm.InsertCassettes(cassettes);

            ICassetteWriter<List<Cassette>> cassetteWriter = new XmlCassetteWriter<List<Cassette>>();
            cassetteWriter.WriteCassettes(cassettes, ConfigurationManager.AppSettings["PathToMoneyXml"]);

            cassetteWriter = new JsonCassetteWriter<List<Cassette>>();
            cassetteWriter.WriteCassettes(cassettes, ConfigurationManager.AppSettings["PathToMoneyJson"]);

            cassetteWriter = new CsvCassetteWriter<List<Cassette>>();
            cassetteWriter.WriteCassettes(cassettes, ConfigurationManager.AppSettings["PathToMoneyCsv"]);

            cassetteWriter = new TxtCassetteWriter();
            cassetteWriter.WriteCassettes(cassettes, ConfigurationManager.AppSettings["PathToMoneyTxt"]);

            while (atm.TotalMoney != 0)
            {
                var readLine = Console.ReadLine();

                decimal requestedSum;
                if (!decimal.TryParse(readLine, out requestedSum) || requestedSum <= decimal.Zero)
                {
                    Console.WriteLine(@"Wrong input");
                    continue;
                }

                var money = atm.WithdrawMoney(requestedSum);
                switch (atm.CurrentState)
                {
                    case AtmState.Ok:
                        Console.WriteLine(money);
                        break;
                    default:
                        Console.WriteLine(atm.CurrentState);
                        break;
                }
            }
        }
    }
}