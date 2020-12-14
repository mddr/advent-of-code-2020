using System;
using System.IO;

namespace day_10
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = "input.txt";
            
            var holder = new AdapterHolder();

            using var sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
                holder.ParseAdapter(line);
            

            var diffs = holder.CalculateDifferences();
            Console.WriteLine($"Result: {diffs}");

            var distinctPaths = holder.CalculateDistinct();
            Console.WriteLine($"Distinct paths: {distinctPaths}");
        }
    }
}
