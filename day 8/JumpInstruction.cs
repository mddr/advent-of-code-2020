using System;

namespace day_8
{
    public class JumpInstruction : IInstruction
    {
        public int AccumulatorDelta => 0;
        public int PositionDelta { get; }
        public int Argument { get; }

        
        public JumpInstruction(int positionDelta)
        {
            PositionDelta = positionDelta;
            Argument = positionDelta;
        }
    }
}