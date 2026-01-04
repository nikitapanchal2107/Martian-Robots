using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Helper
{
    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }  

        public char Orientation { get; set; }

        public bool IsLost { get; set; }
        public Robot(int x, int y, char orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        private static readonly Dictionary<char, (int dx, int dy)> Movement = new()
        {
            ['N'] = (0, 1),
            ['E'] = (1, 0),
            ['S'] = (0, -1),
            ['W'] = (-1, 0)
        };

        private static readonly Dictionary<char, char> LeftTurn = new()
        {
            ['N'] = 'W',
            ['W'] = 'S',
            ['S'] = 'E',
            ['E'] = 'N'
        };


        private static readonly Dictionary<char, char> RightTurn = new()
        {
            ['N'] = 'E',
            ['E'] = 'S',
            ['S'] = 'W',
            ['W'] = 'N'
        };

        public void ExecuteInstruction(string instuction,World world) {
            foreach (char command in instuction) {

                if (IsLost)
                    break;

                Orientation = command switch
                {
                    'L' => LeftTurn[Orientation],
                    'R' => RightTurn[Orientation],
                    _ => Orientation
                };

                if (command == 'F')
                    MoveForward(world);

            }
        }

        private void MoveForward(World world) {
            var (dx, dy) = Movement[Orientation];
            int newX = X + dx;
            int newY = Y + dy;

            if (world.IsOffGrid(newX, newY)) 
            { 
                if (!world.ScentPositions.Contains((X, Y, Orientation))) 
                { 
                    world.ScentPositions.Add((X, Y, Orientation)); 
                    IsLost = true; 
                } 
                return; 
            }
            X = newX;
            Y = newY;


        }

    }
}
