using System;

namespace day_2
{
    public class LineParser
    {
        public Password ParsePassword(string line)
        {
            var trimmed = line.Trim();
            var split = trimmed.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (split.Length != 3)
            {
                throw new ArgumentException("Invalid line :(");
            }

            var (min, max) = ParseBounds(split[0]);
            var letter = ParseLetter(split[1]);
            var sequence = ParseSequence(split[2]);
            return new Password(sequence, letter, min, max);
        }

        private (int, int) ParseBounds(string part)
        {
            var trimmed = part.Trim();
            var split = trimmed.Split('-', StringSplitOptions.RemoveEmptyEntries);
            int.TryParse(split[0], out var min);
            int.TryParse(split[1], out var max);
            return (min, max);
        }
        private char ParseLetter(string part) => part.Trim().Replace(":", string.Empty)[0];
        private string ParseSequence(string part) => part.Trim();
    }
}