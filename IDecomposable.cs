using System.Collections.Generic;

namespace ATM
{
    interface IDecomposable
    {
        Dictionary<Banknote, int> DecomposeMoney(Dictionary<Banknote, int> money, decimal requestedSum, out AtmState state);
    }
}