namespace day_3
{
    public class Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private int MaxX { get; }

        public Coordinate(int x, int y, int maxX)
        {
            X = x;
            Y = y;

            MaxX = maxX;
        }

        public void Move(int deltaX = 3, int deltaY = 1)
        {
            X = (X + deltaX) % MaxX;
            Y += deltaY;
        }
    }
}