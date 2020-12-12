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

        public long Crack(int preambleSize)
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


        private static bool IsNumberValid(long number, List<long> sumComponents)
            => (from t in sumComponents
                    let diff = number - t
                    where diff != t && sumComponents.Contains(diff)
                    select t
                ).Any();
    }
}