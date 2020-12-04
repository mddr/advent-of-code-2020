using System.Collections.Generic;

namespace day_3
{
    public class TobogganMap
    {
        private const char Tree = '#';
        private List<string> Map { get; }
        
        public (int, int) Dimensions {
            get {
                if (Map.Count == 0)
                {
                    return (0, 0);
                }

                var width = Map[0].Length;
                var height = Map.Count;
                return (width, height);
            }
        }

        public TobogganMap()
        {
            Map = new List<string>();
        }

        public void AppendLine(string line)
        {
            Map.Add(line);
        }

        public bool IsTreeAtCoords(int x, int y)
        {
            return AtCoords(x, y) == Tree;
        }

        private char AtCoords(int x, int y)
        {
            return Map[y][x];
        }
    }
}