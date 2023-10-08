using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class CollectionManager
{
    private Dictionary<int, Tuple<long, long>> results = new Dictionary<int, Tuple<long, long>>();
    private object lockObject = new object();

    public void AddResult(int number, long fibResult, long factResult)
    {
        lock (lockObject)
        {
            results.Add(number, Tuple.Create(fibResult, factResult));
        }
    }

    public IReadOnlyDictionary<int, Tuple<long, long>> GetResults()
    {
        return results;
    }
}
