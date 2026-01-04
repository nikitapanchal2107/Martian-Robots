using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Helper
{
    public class World
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public HashSet<(int x, int y, char orientation)> ScentPositions { get;}
        public World(int maxX, int maxY, HashSet<(int x, int y, char orientation)> scentPositions)
        {
            MaxX = maxX;
            MaxY = maxY;
            ScentPositions = scentPositions;
        }

        public bool IsOffGrid(int x, int y)
            => x < 0 || y < 0 || x > MaxX || y > MaxY;
        
    }
}
