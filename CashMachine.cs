using System;
using System.Linq;

namespace ATM
{
    public class CashMachine
    {
        private const decimal Sum = 100000;
        private Money _totalMoney = new Money(Sum);

        public decimal TotalMoney
        {
            get
            {
                return _totalMoney.Banknotes.Sum(item => Decimal.Multiply(item.Value, item.Key.Nominal));
            }
        }

        public Money WithdrawMoney(decimal requestedSum)
        {
            if (TotalMoney < requestedSum) return null;
            _totalMoney = new Money(TotalMoney - requestedSum);
            return new Money(requestedSum);
        }
    }
}