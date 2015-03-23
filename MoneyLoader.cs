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
                    var readLine = reader.ReadLine();
                    if (readLine == null) return new Money();
                    var bufferForSplit = readLine.Split(' ');
                    cassettes.Add(new Banknote(decimal.Parse(bufferForSplit[0])), int.Parse(bufferForSplit[1]));
                }
            }
            return new Money {Banknotes = cassettes};
        }

    }
}