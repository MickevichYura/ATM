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
                if (readLine == null) continue;
                try
                {
                    var money = atm.WithdrawMoney(decimal.Parse(readLine));
                    if (money != null)
                        Console.WriteLine(money);
                    else
                        Console.WriteLine("No such money");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}