using System.Linq;

namespace day_5
{
    public class Seat
    {
        public int SeatId => (Row * 8) + Column;
        
        private int Row { get; }
        private int Column { get; }
        private string Sequence { get; }
        
        private readonly char[] _upperKeys = {'B', 'R'};
        private readonly char[] _lowerKeys = {'F', 'L'};

        public Seat(string sequence)
        {
            Sequence = sequence;
            (Row, Column) = ParseSeat((0, 127), (0, 7));
        }


        private (int, int) ParseSeat((int, int) rows, (int, int) columns)
        {
            var row = ParseSequence(Sequence.Substring(0, 7) , rows);
            var column = ParseSequence(Sequence.Substring(7), columns);
            return (row, column);
        }

        private int ParseSequence(string sequence, (int, int) bounds)
        {
            var (min, max) = bounds;
            if (min == max)
            {
                return max;
            }

            var currentChar = sequence[0];
            return _lowerKeys.Contains(currentChar)
                ? ParseSequence(sequence.Substring(1), (min, min + ((max - min) / 2)))
                : ParseSequence(sequence.Substring(1), (min + (((max - min) / 2) + 1), max));
        }
    }
}