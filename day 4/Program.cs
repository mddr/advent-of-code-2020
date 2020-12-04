using System;
using System.IO;
using System.Linq;

namespace day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = "input.txt";
            
            using var sr = new StreamReader(filename);
            
            var passportCreator = new PassportReader();
            string line;
            while((line = sr.ReadLine()) != null)
            {
                passportCreator.ReadLine(line);
            }
            passportCreator.FinishReading();

            var valid = passportCreator.Passports
                .Count(passport => passport.IsValid());
            Console.WriteLine($"Valid passports: {valid}");
        }
    }
}
