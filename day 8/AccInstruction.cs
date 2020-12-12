using System;

namespace day_8
{
    public class AccInstruction : IInstruction
    {
        public int AccumulatorDelta { get; }
        public int PositionDelta => 1;

        public AccInstruction(int accumulatorDelta)
        {
            AccumulatorDelta = accumulatorDelta;
        }
    }
}