using System.Collections.Generic;
using System.Linq;
using ATM.Decomposition;

namespace ATM
{
    public class CashMachine
    {
        private Money _totalMoney;

        public AtmState CurrentState
        {
            get; private set;
        }

        public CashMachine()
        {
            _totalMoney = new Money();
        }

        public decimal TotalMoney
        {
            get { return _totalMoney.TotalSum; }
        }

        public void InsertCassettes(IEnumerable<Cassette> cassettes)
        {
            _totalMoney = new Money(cassettes.ToDictionary(cassette => cassette.Banknote, cassette => cassette.Number));
        }

        public Money WithdrawMoney(decimal requestedSum)
        {
            IDecomposable algorithm = new DecompositionAlgorithm();
            AtmState state;
            var issuedMoney = new Money(algorithm.DecomposeMoney(_totalMoney.Banknotes, requestedSum, out state));
            CurrentState = state;
            _totalMoney = new Money(TotalMoney - issuedMoney.TotalSum);
            return _totalMoney;
        }
    }
}