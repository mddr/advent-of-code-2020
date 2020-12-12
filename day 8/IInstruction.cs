namespace day_8
{
    public interface IInstruction
    {
        int AccumulatorDelta { get; }
        int PositionDelta { get; }
    }
}