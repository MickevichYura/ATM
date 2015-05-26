using System.Collections.Generic;
using System.Linq;

namespace ATM
{
    public class Money
    {
        public Dictionary<Banknote, int> Banknotes
        {
            get; set;
        }

        public decimal TotalSum
        {
            get { return Banknotes.Sum(item => decimal.Multiply(item.Value, item.Key.Nominal)); }
        }

        public Money()
        {
            Banknotes = new Dictionary<Banknote, int>();
        }

        public Money(Dictionary<Banknote, int> money)
        {
            Banknotes = money;
        }

        public override string ToString()
        {
            return string.Join("\n", Banknotes);
        }
    }
}