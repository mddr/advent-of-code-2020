using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = "input.txt";
            var seats = new List<Seat>();
            
            using var sr = new StreamReader(filename);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var seat = new Seat(line);
                seats.Add(seat);
            }
            sr.Close();

            var sorted = seats.OrderByDescending(seat => seat.SeatId);
            var sortedArr = sorted.ToArray();
            
            var highest = sortedArr.First();
            Console.WriteLine($"Highest: {highest.SeatId}");

            for (var i = 1; i < sortedArr.Length; i++)
            {
                var previous = sortedArr[i - 1].SeatId;
                var current = sortedArr[i].SeatId;

                if (previous - 1 == current) continue;
                
                Console.WriteLine($"Seat ID: {previous - 1}");
                return;
            }
        }
    }
}
