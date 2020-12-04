namespace day_3
{
    public class SlopeChecker
    {
        private TobogganMap Map { get; }
        private (int, int) Dimensions { get; }

        public SlopeChecker(TobogganMap map)
        {
            Map = map;
            Dimensions = Map.Dimensions;
        }

        public ulong CalculateEncounteredTrees(int deltaX, int deltaY)
        {
            var (width, height) = Dimensions;
            var position = new Coordinate(0, 0, width);

            ulong treeCounter = 0;
            while (position.Y < height)
            {
                if (Map.IsTreeAtCoords(position.X, position.Y))
                {
                    treeCounter++;
                }
                position.Move(deltaX, deltaY);
            }

            return treeCounter;
        }
    }
}