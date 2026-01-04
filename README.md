Overview:

- The world is a grid defined by an upper‑right coordinate (e.g., 5 3).
- Each robot has:
	 - A starting position: x y orientation
	 - A sequence of instructions: L, R, F
- Robots execute instructions sequentially.
- If a robot moves off the grid:
	 - It becomes LOST
	 - A scent is left at the last valid position
	 - Future robots ignore moves that would repeat the same fall.
- Validating input for Gridsize,Robot Position and instructions
	 - Grid size shouldn't be more than 50
	 - Robot Postion shouldn't exist more than Grid size and it should be from ('N,S,W,E')
	 - Instruction shouldn't be more than 100 characters
	 

Tech Choices -> Created c# console app as it was mentioned that it shouldn't take more than 2-3 hours so kept it simple, focused on actual logic and unit test suite than user interface.

.NET 8 -> The latest LTS version, offering:
	- Fast startup
	- Modern runtime features
	- Long-term support
C# 12
	- Top‑level statements
	- File‑scoped namespaces
	- Switch expressions
	- Cleaner, more expressive code
	
	
KISS Architecture

The problem is small and self-contained
Adding abstractions (interfaces, factories, DI containers) would add complexity.
So the solution uses:
	- Two small classes (Robot, World)
	- One simple Program.cs

This keeps the code:
	- Easy to read
	- Easy to test
	- Easy to extend
	
	
xUnit Test Suite
xUnit was chosen because:
	- It’s the standard test framework for .NET testing
	- It integrates cleanly with dotnet test
	- It encourages small, isolated tests
	- It requires no setup overhead

The test suite validates:
	- Turning left/right
	- Moving forward
	- Falling off the grid
	- Scent logic
	- Sample input/output from the original problem
	
	
Running the Application
1.Clone the MartianRobots from provided github link  

2.In the file explorer type 'cmd' at file path at the top and press Enter.

3.Command prompt will be opened and type 'cd MartianRobots'

4.To Run the console app - dotnet run

5.Follow the prompts on Console


Running the xUnit tests
1.Navigate to the test project folder and run:
dotnet test

2.You will see output similar to:
7 Passed, 0 Failed


Commit History:
1. Initialize .NET 8 console application for Martian Robots
2. Implement initial Robot and World classes with basic movement logic
3. Add scent tracking and off-grid detection to Robot and World
4. Implement console input/output flow - Build Program.cs with interactive input for grid, robot start, and instructions
5. Add validation for grid size, robot start position, and instruction characters
6. Enforce max coordinate limit (50) and max instruction length (100 chars)
7. Extract input validation into dedicated helper methods to simplify Program.cs
8. Introduce InputValidator class - Move validation helpers into InputValidator class to keep Program.cs file clean and structured
9. Add xUnit test project and initial test structure
10. Add tests for Robot movement, turning, scent logic, and LOST behaviour
11. Improve naming, simplify switch expressions, and clean up minor code smells
13. Add README with instructions, architecture overview, and problem explanation, running instuction and commit History.
14. Expand README to include validation rationale and xUnit testing strategy
15. Could have added tests suite for InputValidator (grid, start position, instructions) but running out of time.
