using System.Collections.Generic;
using System.IO;

namespace day1
{
    public static class FileReader
    {
        public static HashSet<int> ReadNumbers(string filename)
        {
            var numbers = new HashSet<int>();
            
            using var sr = new StreamReader(filename);
            string line;
            do
            {
                line = sr.ReadLine();
                if (string.IsNullOrEmpty(line)) continue;
                    
                int.TryParse(line, out var number);
                numbers.Add(number);
                numbers.Add(number);
            } while (!string.IsNullOrEmpty(line));

            return numbers;
        }
    }
}