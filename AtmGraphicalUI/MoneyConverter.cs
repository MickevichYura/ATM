using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
                    moneyStringRepresentation.AppendFormat("{0} - {1};", pair.Key.Nominal, pair.Value);
            }

            return moneyStringRepresentation.ToString();
        }

        public static ListBox.ObjectCollection ConvertToListBox(Money money)
        {
            if (money == null) return new ListBox().Items;
            ListBox listBoxMoney = new ListBox();

            foreach (KeyValuePair<Banknote, int> pair in money.Banknotes)
            {
                if (pair.Value != 0)
                listBoxMoney.Items.Add(string.Format("Banknote: {0}  " + "Amount: {1}", pair.Key.Nominal,
                    pair.Value));
            }
            return listBoxMoney.Items;
        }


        public static Dictionary<decimal, int> ConvertToDictionary(Money money)
        {
            return money == null ? new Dictionary<decimal, int>() : money.Banknotes.Where(pair => pair.Value != 0).ToDictionary(pair => pair.Key.Nominal, pair => pair.Value);
        }
    }
}
