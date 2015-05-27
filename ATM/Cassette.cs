using System;
using System.Runtime.Serialization;

namespace ATM
{
    [Serializable]
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

        public decimal TotalMoney
        {
            get { return Banknote.Nominal * Number; }
        }
        
        public Cassette(Banknote banknote, int number)
        {
            Number = number;
            Banknote = banknote;
        }

    }
}
