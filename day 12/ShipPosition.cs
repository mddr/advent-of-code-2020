using System;
using System.Collections.Generic;

namespace day_12
{
    public class ShipPosition
    {
        public int ManhattanDistance => Math.Abs(EastPosition) + Math.Abs(NorthPosition);
        
        private int EastPosition { get; set; }
        private int NorthPosition { get; set; }
        public int Angle { get; set; }
        
        private Dictionary<char, Action<int>> Commands { get; }

        public ShipPosition()
        {
            EastPosition = 0;
            NorthPosition = 0;
            Angle = 0; // facing east

            Commands = new Dictionary<char, Action<int>>
            {
                ['N'] = MoveNorth,
                ['S'] = MoveSouth,
                ['E'] = MoveEast,
                ['W'] = MoveWest,
                ['L'] = RotateLeft,
                ['R'] = RotateRight,
                ['F'] = MoveForward
            };
        }

        public void MakeMove(char command, int value)
        {
            Commands[command].Invoke(value);
        }

        private void RotateRight(int angle)
        {
            Angle -= angle;
            if (Angle < 0)
            {
                Angle = 360 + Angle;
            }
        }

        private void RotateLeft(int angle) => Angle = (Angle + angle) % 360;
        private void MoveNorth(int distance) => NorthPosition += distance;
        private void MoveSouth(int distance) => NorthPosition -= distance;
        private void MoveEast(int distance) => EastPosition += distance;
        private void MoveWest(int distance) => EastPosition -= distance;

        private void MoveForward(int distance)
        {
            var direction = Angle / 90;
            switch (direction)
            {
                case 0:
                    MoveEast(distance);
                    break;
                case 1:
                    MoveNorth(distance);
                    break;
                case 2:
                    MoveWest(distance);
                    break;
                case 3:
                    MoveSouth(distance);
                    break;
                default:
                    throw new Exception($"Invalid direction: {direction}");
            }
        }

        public override string ToString()
        {
            return $"East: {EastPosition}, North: {NorthPosition}, Angle: {Angle}";
        }
    }
}