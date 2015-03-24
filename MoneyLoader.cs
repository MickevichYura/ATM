using System.Collections.Generic;
using System.IO;

namespace ATM
{
    public static class MoneyLoader
    {
        private const string Path = "money.txt";

        public static Money LoadMoney()
        {
            Dictionary<Banknote, int> cassettes = new Dictionary<Banknote, int>();
            using (StreamReader reader = new StreamReader(Path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) return new Money();
                    var casseteInfo = line.Split(' ');
                    cassettes.Add(new Banknote(decimal.Parse(casseteInfo[0])), int.Parse(casseteInfo[1]));
                }
            }
            return new Money {Banknotes = cassettes};
        }

    }
}