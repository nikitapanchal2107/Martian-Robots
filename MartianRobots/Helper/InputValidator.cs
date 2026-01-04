using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Helper
{
    public static class InputValidator
    {
        public static (int maxX, int maxY) ReadGridSize()
        {
            while (true)
            {
                var gridPart = Console.ReadLine()!.Trim().Split(' ');
                if (gridPart.Length == 2 &&
                    int.TryParse(gridPart[0], out int maxX) &&
                    int.TryParse(gridPart[1], out int maxY) &&
                    maxX is >= 0 and <= 50 &&
                    maxY is >= 0 and <= 50)
                {
                    return (maxX, maxY);
                }

                Console.Write("Invalid grid size. Enter two numbers between 0 and 50 (e.g., 5 3): ");

            }
        }

        public static (int x, int y, char orientation) ReadRobotStart(string input, int maxX, int maxY)
        {
            while (true)
            {
                var parts = input.Trim().Split(' ');

                if (parts.Length == 3 &&
                    int.TryParse(parts[0], out int x) &&
                    int.TryParse(parts[1], out int y) &&
                    parts[2].Length == 1 &&
                    "NESW".Contains(parts[2][0]) &&
                    x >= 0 && x <= maxX &&
                    y >= 0 && y <= maxY)
                {
                    return (x, y, parts[2][0]);
                }

                Console.Write("Invalid start position. Enter again (e.g., 1 1 E): ");
                input = Console.ReadLine()!;
            }
        }

        public static void ReadInstructions(string input)
        {

            if (!(input.Length is > 0 and <= 100 &&
                input.All(c => c is 'L' or 'R' or 'F')))
            {
                Console.Write("Invalid instructions. Use only L, R, F (max 99 chars): ");
                Console.ReadLine();
            }

        }


    }
}
