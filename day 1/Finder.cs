using System;
using System.Collections.Generic;

namespace day1
{
    public static class Finder
    {
        public static int FindTwo(IEnumerable<int> numbers, int properSum)
        {
            var numbersCopy = new List<int>(numbers);
            numbersCopy.Sort();
            for (var i = 0; i < numbersCopy.Count - 1; i++)
            {
                var fromStart = numbersCopy[i];
                
                for (var j = numbersCopy.Count - 1; j > 0; j--)
                {
                    var fromEnd = numbersCopy[j];
                    var sum = fromStart + fromEnd;
                    if (sum > properSum)
                        j--;
                    else if (sum < properSum)
                        i++;
                    else
                        return fromStart * fromEnd;
                }
            }
            throw new Exception("Not found :(");
        }
        
        public static int FindThree(HashSet<int> numbers, int properSum)
        {
            var numbersCopy = new List<int>(numbers);
            for (var i = 0; i < numbers.Count - 1; i++)
            {
                var first = numbersCopy[i];
                for (var j = i; j < numbers.Count; j++)
                {
                    var second = numbersCopy[j];
                    var remaining = 2020 - first - second;
                    if (numbers.Contains(remaining))
                    {
                        return first * second * remaining;
                    }
                }
            }
            throw new Exception("Not found :(");
        }
    }
}