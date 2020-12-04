using System;

namespace day1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var numbers = FileReader.ReadNumbers("input.txt");
            var part1Result = Finder.FindTwo(numbers, 2020);
            Console.WriteLine($"Result of part 1: {part1Result}");

            var part2Result = Finder.FindThree(numbers, 2020);
            Console.WriteLine($"Result of part 2: {part2Result}");
        }
    }
}
