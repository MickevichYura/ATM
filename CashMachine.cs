using System;
using System.Linq;

namespace ATM
{
    public class CashMachine
    {
        private Money _totalMoney;

        public CashMachine()
        {
            _totalMoney = new Money();
        }

        public decimal TotalMoney
        {
            get
            {
                return _totalMoney.Banknotes.Sum(item => Decimal.Multiply(item.Value, item.Key.Nominal));
            }
        }

        public void InsertCassettes(Money cassettes)
        {
            _totalMoney = cassettes;
        }

        public Money WithdrawMoney(decimal requestedSum)
        {
            if (TotalMoney < requestedSum) return null;
            _totalMoney = new Money(TotalMoney - requestedSum);
            return new Money(requestedSum);
        }
    }
}