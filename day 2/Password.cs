namespace day_2
{
    public class Password
    {
        public string Sequence { get; }
        public char Letter { get; }
        public int LowerBound { get; }
        public int UpperBound { get; }

        public Password(string sequence, char letter, int lowerBound, int upperBound)
        {
            Sequence = sequence;
            Letter = letter;
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }
    }
}