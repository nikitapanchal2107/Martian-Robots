// See https://aka.ms/new-console-template for more information
using MartianRobots.Helper;
using System.Numerics;

Console.Write("Enter grid size (e.g., 5 3):");
var (maxX, maxY) = InputValidator.ReadGridSize();
var scents = new HashSet<(int x, int y, char orientation)>();
var world = new World(maxX, maxY, scents);

while (true)
{
    Console.Write("Enter robot start position (e.g., 1 1 E) or blank to exit:");
    var startInput = Console.ReadLine()!.Trim();

    if (string.IsNullOrWhiteSpace(startInput))
        break;

    var (x, y, orientation) = InputValidator.ReadRobotStart(startInput, maxX, maxY);

    Console.Write("Enter instructions (e.g., RFRFRFRF) or blank to exit::");
    var instructions = Console.ReadLine()!.Trim();

    if (string.IsNullOrWhiteSpace(instructions))
        break;
    InputValidator.ReadInstructions(instructions);


    var robot = new Robot(x, y, orientation);
    robot.ExecuteInstruction(instructions, world);

    Console.WriteLine($"Robot current Postion: {robot.X} {robot.Y} {robot.Orientation}{(robot.IsLost ? " LOST" : "")} ");

}



