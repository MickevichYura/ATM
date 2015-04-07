using System;

namespace ATM
{
    public static class Program
    {
        private const string Path = "money.txt";

        private static void Main()
        {
            var atm = new CashMachine();
            atm.InsertCassettes(CasseteReader.ReadCassete(Path));
            Console.WriteLine(atm.TotalMoney);

            while (atm.TotalMoney != 0)
            {
                var readLine = Console.ReadLine();

                decimal requestedSum;
                if (!decimal.TryParse(readLine, out requestedSum) || requestedSum <= Decimal.Zero)
                {
                    Console.WriteLine("Wrong input");
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