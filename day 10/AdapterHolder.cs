using System.Collections.Generic;
using System.Linq;

namespace day_10
{
    public class AdapterHolder
    {
        private SortedSet<int> Adapters { get; }

        public AdapterHolder()
        {
            Adapters = new SortedSet<int>();
        }

        public void ParseAdapter(string line)
            => Adapters.Add(int.Parse(line));


        public long CalculateDifferences()
        {
            var differences = new Dictionary<int, int> {{1, 0}, {2, 0}, {3, 1}};
            var adaptersCopy = Adapters.Prepend(0).ToList();
            
            for (var i = 0; i < adaptersCopy.Count - 1; i++)
            {
                var element = adaptersCopy[i];
                var nextElement = adaptersCopy[i + 1];
                var diff = nextElement - element;
                differences[diff]++;
            }

            return differences[1] * differences[3];
        }

        public long CalculateDistinct()
        {
            var pathsToAdapter = new Dictionary<int, long> {{0, 1}};
            foreach (var jolt in Adapters)
                pathsToAdapter[jolt] = pathsToAdapter.GetValueOrDefault(jolt - 1) +
                                       pathsToAdapter.GetValueOrDefault(jolt - 2) +
                                       pathsToAdapter.GetValueOrDefault(jolt - 3);
            
            return pathsToAdapter[Adapters.Last()];
        }
    }
}