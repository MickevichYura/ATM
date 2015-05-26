using System.Collections.Generic;
using System.Linq;

namespace ATM.Decomposition
{
    public class DecompositionAlgorithm : IDecomposable
    {
        Dictionary<Banknote, int> IDecomposable.DecomposeMoney(Dictionary<Banknote, int> money, decimal requestedSum,
            out AtmState state)
        {
            if (TotalMoney(money) < requestedSum)
            {
                state = AtmState.NotEnoughMoney;
                return new Dictionary<Banknote, int>();
            }

            if (TotalMoney(money) < requestedSum)
            {
                state = AtmState.NotEnoughMoney;
                return null;
            }

            bool isSumsLess = false;

            List<List<decimal>> oldDegree = new List<List<decimal>>();

            List<decimal> firstSum = new List<decimal> {0};
            firstSum.AddRange(money.Select(i => 0).Select(dummy => (decimal) dummy));

            oldDegree.Add(firstSum);

            do
            {
                List<List<decimal>> newDegree = new List<List<decimal>>();

                for (int i = 0; i < oldDegree.Count(); i++)
                {
                    isSumsLess = false;

                    for (int j = 0; j < money.Count(); j++)
                    {
                        if (oldDegree[i][0] + money.ElementAt(j).Key.Nominal <= requestedSum &&
                            oldDegree[i][j + 1] + 1 <= money.ElementAt(j).Value)
                        {
                            List<decimal> newSum = new List<decimal>(oldDegree[i]);
                            newSum[0] += money.ElementAt(j).Key.Nominal;
                            newSum[j + 1]++;

                            newDegree.Add(newSum);
                            isSumsLess = true;

                            if (newDegree[newDegree.Count() - 1][0] != requestedSum) continue;
                            state = AtmState.Ok;
                            Dictionary<Banknote, int> decomposedSum = new Dictionary<Banknote, int>();
                            for (int h = 1; h < newDegree[i].Count(); h++)
                            {
                                decomposedSum.Add(money.ElementAt(h - 1).Key,
                                    (int) newDegree[newDegree.Count() - 1][h]);
                            }
                            Money decomposedMoney = new Money {Banknotes = decomposedSum};
                            return decomposedMoney.Banknotes;
                        }
                    }
                }
                oldDegree = newDegree;
            } while (isSumsLess);

            state = AtmState.ImpossibleToCollectMoney;

            return null;
        }

        private static decimal TotalMoney(Dictionary<Banknote, int> money)
        {
            return money.Sum(item => decimal.Multiply(item.Value, item.Key.Nominal));
        }
    }
}
