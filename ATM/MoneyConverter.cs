using System.Collections.Generic;
using System.Text;

namespace ATM
{
    internal static class MoneyConverter
    {
        public static string ConvertToString(Money money)
        {
            if (money == null) return "null";
            StringBuilder moneyStringRepresentation = new StringBuilder();

            foreach (KeyValuePair<Banknote, int> pair in money.Banknotes)
            {
                if (pair.Value != 0)
                    moneyStringRepresentation.AppendFormat("{0}-{1}; ", pair.Key.Nominal, pair.Value);
            }

            return moneyStringRepresentation.ToString();
        }
    }
}
