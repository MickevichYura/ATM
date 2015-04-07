namespace ATM
{
    public class Cassette
    {
        public Banknote Banknote
        {
            get;
            private set;
        }

        public int Number
        {
            get; private set;
        }
        
        public Cassette(Banknote banknote, int number)
        {
            Number = number;
            Banknote = banknote;
        }

        public void Erase(int number)
        {
            Number -= number;
        }

    }
}