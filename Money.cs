using System.Collections.Generic;

namespace ATM
{
    public class Money
    {
        public Dictionary<Banknote, int> Banknotes
        {
            get; set;
        }

        public Money()
        {
            Banknotes = new Dictionary<Banknote, int>();
        }

        public Money(decimal requestedSum)
        {
            Banknotes = new Dictionary<Banknote, int> {{new Banknote(requestedSum), 1}};
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