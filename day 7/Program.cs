using System;
using System.IO;

namespace day_7
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = "input.txt";
            
            var reader = new BagReader();
            
            using var sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                reader.ReadLine(line);
            }

            var amount = reader.CountBagHolders();

            Console.WriteLine($"Reader length: {reader.Bags.Count}");
            Console.WriteLine($"Amount: {amount}");
        }
    }
}
