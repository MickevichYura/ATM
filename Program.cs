using System;
using System.Configuration;

namespace ATM
{
    public static class Program
    {
        private static void Main()
        {
            var atm = new CashMachine();
            atm.InsertCassettes(CassetteReader.ReadCassette(ConfigurationManager.AppSettings["Path"]));

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