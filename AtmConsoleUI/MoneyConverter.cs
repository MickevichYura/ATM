using System;
using System.Collections.Generic;
using System.Text;
using ATM;

namespace AtmConsoleUI
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
                    moneyStringRepresentation.AppendFormat("{0} - {1};{2}", pair.Key.Nominal, pair.Value, Environment.NewLine);
            }

            return moneyStringRepresentation.ToString();
        }
    }
}
