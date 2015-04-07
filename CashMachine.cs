using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM
{
    public class CashMachine
    {
        private Money _totalMoney;
        public AtmState CurrentState;

        public CashMachine()
        {
            _totalMoney = new Money();
        }

        public decimal TotalMoney
        {
            get { return _totalMoney.Banknotes.Sum(item => Decimal.Multiply(item.Value, item.Key.Nominal)); }
        }

        public void InsertCassettes(List<Cassette> cassettes)
        {
            _totalMoney = new Money(cassettes.ToDictionary(cassete => cassete.Banknote, cassete => cassete.Number));
        }

        public Money WithdrawMoney(decimal requestedSum)
        {
            if (TotalMoney < requestedSum)
            {
                CurrentState = AtmState.NotEnoughMoney;
                return new Money();
            }
            CurrentState = AtmState.Ok;
            _totalMoney = new Money(TotalMoney - requestedSum);
            return new Money(requestedSum);
        }
    }
}