using System;
using System.IO;

namespace day_12
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = "input.txt";

            var position = new ShipPosition();

            using var sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var command = line[0];
                var value = int.Parse(line.Substring(1));
                position.MakeMove(command, value);
            }
            Console.WriteLine(position.ManhattanDistance);
        }

        private static void RunPartOneTests()
        {
            TestRightRotation(0, 90, 270);
            TestRightRotation(90, 90, 0);
            TestRightRotation(180, 90, 90);
            TestRightRotation(270, 90, 180);
            TestRightRotation(0, 180, 180);
            TestRightRotation(90, 180, 270);
            TestRightRotation(0, 270, 90);
            TestRightRotation(90, 270, 180);
            TestRightRotation(180, 270, 270);
            TestRightRotation(270, 270, 0);
        }

        private static void TestRightRotation(int startAngle, int rotationRight, int expected)
        {
            var debugPos = new ShipPosition();
            debugPos.MakeMove('L', startAngle);
            debugPos.MakeMove('R', rotationRight);

            var msg = expected == debugPos.Angle ? string.Empty : "FAIL -> ";
            Console.WriteLine($"{msg}Expected: {expected}; Actual: {debugPos.Angle}");
        }
    }
}
