﻿using System;
using System.IO;

namespace day_8
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = "input.txt";
            
            var runner = new InstructionsRunner();
            
            using var sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                runner.ParseInstruction(line);
            }

            var result = runner.Run();
            Console.WriteLine($"Part one result: {result}");
        }
    }
}
