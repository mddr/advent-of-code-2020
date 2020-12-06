using System;
using System.IO;

namespace day_6
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = "input.txt";

            var answerCounter = 0;
            // to run part 1 create GroupReaderPartOne here
            var reader = new GroupReaderPartTwo();

            using var sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line != string.Empty)
                    reader.ReadLine(line);
                else
                {
                    answerCounter += reader.GetAnswersCount();
                    reader.InitializeNewGroup();
                }
            }
            answerCounter += reader.GetAnswersCount();
            reader.InitializeNewGroup();

            Console.WriteLine($"Answers: {answerCounter}");
        }
    }
}
