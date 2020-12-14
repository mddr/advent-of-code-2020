using System.Collections.Generic;
using System.Linq;

namespace day_10
{
    public class AdapterHolder
    {
        private List<int> Adapters { get; set; }

        public AdapterHolder()
        {
            Adapters = new List<int>();
        }

        public void ParseAdapter(string line)
            => Adapters.Add(int.Parse(line));


        public long CalculateDifferences(int startWith = 0)
        {
            var differences = new Dictionary<int, int> {{1, 0}, {2, 0}, {3, 1}};
            var copy = Adapters.Prepend(startWith);
            var sortedAdapters = copy.OrderBy(a => a).ToList();
            
            for (var i = 0; i < sortedAdapters.Count - 1; i++)
            {
                var element = sortedAdapters[i];
                var nextElement = sortedAdapters[i + 1];
                var diff = nextElement - element;
                differences[diff]++;
            }

            return differences[1] * differences[3];
        }
    }
}