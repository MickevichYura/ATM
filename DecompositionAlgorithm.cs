using System.Collections.Generic;
using System.Linq;

namespace ATM
{
    internal class DecompositionAlgorithm : IDecomposable
    {
        Dictionary<Banknote, int> IDecomposable.DecomposeMoney(Dictionary<Banknote, int> money, decimal requestedSum,
            out AtmState state)
        {       
            if (TotalMoney(money) < requestedSum)
            {
                state = AtmState.NotEnoughMoney;
                return new Dictionary<Banknote, int>();
            }
            state = AtmState.Ok;
            return new Dictionary<Banknote, int> {{new Banknote(requestedSum), 1}};
        }

        private static decimal TotalMoney(Dictionary<Banknote, int> money)
        {
            return money.Sum(item => decimal.Multiply(item.Value, item.Key.Nominal));
        }
    }
}