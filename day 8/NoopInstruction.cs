namespace day_8
{
    public class NoopInstruction : IInstruction
    {
        public int AccumulatorDelta => 0;
        public int PositionDelta => 1;
    }
}