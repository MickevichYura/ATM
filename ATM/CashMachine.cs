using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using ATM.Decomposition;

namespace ATM
{
    [Serializable]
    public class CashMachine
    {
        public Money AllMoney { get; private set; }

        public AtmState CurrentState { get; private set; }

        public CashMachine()
        {
            AllMoney = new Money();
        }

        public decimal TotalMoney
        {
            get { return AllMoney.TotalSum; }
        }

        public void InsertCassettes(IEnumerable<Cassette> cassettes)
        {
            AllMoney =
                new Money(
                    cassettes.OrderByDescending(cassette => cassette.Banknote.Nominal)
                        .ToDictionary(cassette => cassette.Banknote, cassette => cassette.Number));

        }

        public void DeleteCassettes()
        {
            AllMoney = new Money();
        }

        public Money WithdrawMoney(decimal requestedSum)
        {
            IDecomposable algorithm = new DecompositionAlgorithm();
            AtmState state;
            Money issuedMoney = new Money(algorithm.DecomposeMoney(AllMoney.Banknotes, requestedSum, out state));
            CurrentState = state;

            if (CurrentState == AtmState.Ok)
            {
                UpdateMoney(issuedMoney);
            }

            return issuedMoney;
        }

        private void UpdateMoney(Money issuedMoney)
        {
            foreach (KeyValuePair<Banknote, int> pair in issuedMoney.Banknotes)
            {
                AllMoney.Banknotes[pair.Key] -= pair.Value;
            }
        }

        public void Serialize(string fileName)
        {
            Stream testFileStream = File.Create(fileName);
            var serializer = new BinaryFormatter();
            serializer.Serialize(testFileStream, this);
            testFileStream.Close();
        }

        public static CashMachine Deserialize(string fileName)
        {
            Stream stream = Stream.Null;
            try
            {
                stream = File.OpenRead(fileName);
                var deserializer = new BinaryFormatter();
                var cashMachine = (CashMachine) deserializer.Deserialize(stream);
                stream.Close();
                return cashMachine;
            }
            catch (Exception)
            {
                stream.Close();
                return null;
            }

        }
    }
}
