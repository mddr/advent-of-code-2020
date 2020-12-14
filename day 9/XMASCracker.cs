using System;
using System.Collections.Generic;
using System.Linq;

namespace day_9
{
    public class XmasCracker
    {
        private List<long> Numbers { get; }

        public XmasCracker()
        {
            Numbers = new List<long>();
        }

        public void ParseNumber(string line)
        {
            var parsed = long.Parse(line);
            Numbers.Add(parsed);
        }

        public long FindInvalidNumber(int preambleSize)
        {
            for (var i = 0; i < Numbers.Count; i++)
            {
                var currentIndex = i + preambleSize;
                var sumComponents = Numbers.GetRange(i, preambleSize);
                var isValid = IsNumberValid(Numbers[currentIndex], sumComponents);
                if (!isValid)
                    return Numbers[currentIndex];
            }
            throw new Exception("Not found");
        }

        public long FindEncryptionWeakness(long invalidNumber)
        {
            var components = new List<long>();

            var found = false;
            foreach (var element in Numbers)
            {
                var sum = components.Sum();
                if (sum == invalidNumber)
                {
                    found = true;
                    break;
                }

                while (sum > invalidNumber)
                {
                    components.RemoveAt(0);
                    sum = components.Sum();
                }
                if (sum == invalidNumber)
                {
                    found = true;
                    break;
                }
                
                components.Add(element);
            }

            if (!found)
                throw new Exception("Solution not found");
            if (components.Count == 1) 
                throw new Exception("Only 1 component");
            
            var ordered = components.OrderBy(x => x).ToList();
            return ordered.First() + ordered.Last();
        }


        private static bool IsNumberValid(long number, List<long> sumComponents)
            => (from t in sumComponents
                    let diff = number - t
                    where diff != t && sumComponents.Contains(diff)
                    select t
                ).Any();
    }
}