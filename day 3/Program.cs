using System;
using System.IO;
using System.Linq;

namespace day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = "input.txt";

            var tobogganMap = CreateMap(filename);
            var slopeChecker = new SlopeChecker(tobogganMap);
            
            var results = new[]
            {
                slopeChecker.CalculateEncounteredTrees(1, 1),
                slopeChecker.CalculateEncounteredTrees(3, 1),
                slopeChecker.CalculateEncounteredTrees(5, 1),
                slopeChecker.CalculateEncounteredTrees(7, 1),
                slopeChecker.CalculateEncounteredTrees(1, 2),
            };

            var multipliedTrees = results
                .Aggregate(1UL, (acc, counter) => acc * counter);
            Console.WriteLine($"Multiplied: {multipliedTrees}");
        }

        static TobogganMap CreateMap(string filename)
        {
            using var sr = new StreamReader(filename);

            var tobogganMap = new TobogganMap();
            
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                tobogganMap.AppendLine(line);
            }
            sr.Close();
            return tobogganMap;
        } 
    }
}
