using System.Runtime.Serialization;

namespace ATM
{
    [DataContract]
    public class Cassette
    {
        [DataMember]
        public int Number
        {
            get;
            private set;
        }

        [DataMember]
        public Banknote Banknote
        {
            get;
            private set;
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
