using System;
using System.Collections.Generic;
using System.Linq;
using ATM.Decomposition;

namespace ATM
{
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
    }
}
