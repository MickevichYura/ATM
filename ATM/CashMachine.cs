using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ATM.Decomposition;
using log4net;

namespace ATM
{
    [Serializable]
    public class CashMachine
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CashMachine));

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
            Log.Info("Start inserting cassettes");
            AllMoney =
                new Money(
                    cassettes.OrderByDescending(cassette => cassette.Banknote.Nominal)
                        .ToDictionary(cassette => cassette.Banknote, cassette => cassette.Number));
            Log.Info("Cassettes are inserted successfully");
        }

        public void DeleteCassettes()
        {
            Log.Info("Start deleting cassettes");
            AllMoney = new Money();
            Log.Info("Cassettes are deleted");
        }

        public Money WithdrawMoney(decimal requestedSum)
        {
            Log.Info("Request sum for withdraw " + requestedSum);
            IDecomposable algorithm = new DecompositionAlgorithm();
            AtmState state;
            Money issuedMoney = new Money(algorithm.DecomposeMoney(AllMoney.Banknotes, requestedSum, out state));
            CurrentState = state;

            if (CurrentState == AtmState.Ok)
            {
                UpdateMoney(issuedMoney);
            }
            //Log.Info(string.Format("State: {0}. Issued money {1}", CurrentState, issuedMoney));
            return issuedMoney;
        }

        private void UpdateMoney(Money issuedMoney)
        {
            foreach (KeyValuePair<Banknote, int> pair in issuedMoney.Banknotes)
            {
                AllMoney.Banknotes[pair.Key] -= pair.Value;
            }
        }

        public void Serialize(string filename)
        {
            Log.Info(string.Format("Start serialization to {0}", filename));
            Stream fileStream = Stream.Null;
            try
            {
                fileStream = File.Create(filename);
                var serializer = new BinaryFormatter();
                serializer.Serialize(fileStream, this);
                Log.Info(string.Format("Serialization to {0} was successfull", filename));
            }
            catch (SerializationException e)
            {
                fileStream.Close();
                Log.Error(string.Format("Error in serialization to {0}. {1}", filename, e));
            }
        }

        public static CashMachine Deserialize(string filename)
        {
            Log.Info(string.Format("Start deserialization from {0}", filename));
            Stream fileStream = Stream.Null;
            try
            {
                fileStream = File.OpenRead(filename);
                var deserializer = new BinaryFormatter();
                var cashMachine = (CashMachine) deserializer.Deserialize(fileStream);
                fileStream.Close();
                Log.Info(string.Format("Deserialization from {0} was successfull", filename));
                return cashMachine;
            }
            catch (FileNotFoundException e)
            {
                fileStream.Close();
                Log.Error(string.Format("Error in deserialization from {0}.\n{1}", e.FileName, e.Message));
                return null;
            }

        }
    }
}
