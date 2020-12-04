using System;
using System.IO;

namespace day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = "input.txt";

            var parser = new LineParser();
            // to check Part 1 just create PartOneValidator here
            var validator = new PartTwoValidator();
            var validCounter = 0;
            
            using var sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var password = parser.ParsePassword(line);
                if (validator.IsValid(password))
                    validCounter++;
            }
            sr.Close();

            Console.WriteLine($"Valid passwords: {validCounter}");
        }
    }
}
