using System;
using System.IO;

namespace day_9
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = "input.txt";
            
            var cracker = new XmasCracker();
            
            using var sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                cracker.ParseNumber(line);
            }

            var result = cracker.FindInvalidNumber(25);
            Console.WriteLine($"Result: {result}");

            var weakness = cracker.FindEncryptionWeakness(result);
            Console.WriteLine($"Weakness: {weakness}");
        }
    }
}
