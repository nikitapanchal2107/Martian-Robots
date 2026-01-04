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
1.Extract the file MartianRobots and open that proejct in file explorer  

2.In the file explorer type 'cmd' at the top and Enter.

3.Command prompt will be opened and type 'cd MartianRobots'

4.Run the console app
type dotnet run

5.Follow the prompts on Console


Running the xUnit tests
1.Navigate to the test project folder and run:
dotnet test

2.You will see output similar to:
7 Passed, 0 Failed






