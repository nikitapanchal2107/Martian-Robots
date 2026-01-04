using MartianRobots.Helper;

namespace MartianRobots.Test
{
    public class RobotTests
    {
        private World CreateWorld() { 
         return new World(5,3,new HashSet<(int, int, char)>());
        }

        [Fact]
        public void Robot_ShouldEndAt_1_1_E()
        {
            var world = CreateWorld();
            var robot = new Robot(1, 1, 'E');
            robot.ExecuteInstruction("RFRFRFRF", world);
            Assert.Equal(1, robot.X);
            Assert.Equal(1, robot.Y);
            Assert.Equal('E', robot.Orientation);
            Assert.False(robot.IsLost);
        }

        [Fact]
        public void Robot_ShouldEndAt_3_3_N_LOST()
        {
            var world = CreateWorld();
            var robot = new Robot(3, 2, 'N');
            robot.ExecuteInstruction("FRRFLLFFRRFLL", world);
            Assert.Equal(3, robot.X);
            Assert.Equal(3, robot.Y);
            Assert.Equal('N', robot.Orientation);
            Assert.True(robot.IsLost);
        }

        [Fact]
        public void Robot_ShouldEndAt_2_3_S()
        {
            var world = CreateWorld();
            var robot1 = new Robot(3, 2, 'N');
            robot1.ExecuteInstruction("FRRFLLFFRRFLL", world);

            var robot2 = new Robot(0, 3, 'W');
            robot2.ExecuteInstruction("LLFFFLFLFL", world);


            Assert.Equal(2, robot2.X);
            Assert.Equal(3, robot2.Y);
            Assert.Equal('S', robot2.Orientation);
            Assert.False(robot2.IsLost);
        }

        [Fact]
        public void Robot_ShouldIgnoreForward_WhenScentExists()
        {  
            var world = CreateWorld();
            var robot1 = new Robot(3, 2, 'N');
            robot1.ExecuteInstruction("FF", world);
            Assert.True(robot1.IsLost);
            Assert.Contains((3, 3, 'N'), world.ScentPositions);

            var robot2 = new Robot(3, 3, 'N');
            robot2.ExecuteInstruction("F", world);

            Assert.Equal(3, robot2.X);
            Assert.Equal(3, robot2.Y);      
            Assert.Equal('N', robot2.Orientation);
            Assert.False(robot2.IsLost);
        }

        [Fact]
        public void Robot_ShouldTurnLeftCorrectly()
        {
            var world = CreateWorld();
            var robot = new Robot(1, 1, 'N');
            robot.ExecuteInstruction("L", world);
            Assert.Equal('W', robot.Orientation);
            robot.ExecuteInstruction("L", world);
            Assert.Equal('S', robot.Orientation);
            robot.ExecuteInstruction("L", world);
            Assert.Equal('E', robot.Orientation);
            robot.ExecuteInstruction("L", world);
            Assert.Equal('N', robot.Orientation);
        }

        [Fact]
        public void Robot_ShouldTurnRightCorrectly()
        {
            var world = CreateWorld();
            var robot = new Robot(1, 1, 'N');
            robot.ExecuteInstruction("R", world);
            Assert.Equal('E', robot.Orientation);
            robot.ExecuteInstruction("R", world);
            Assert.Equal('S', robot.Orientation);
            robot.ExecuteInstruction("R", world);
            Assert.Equal('W', robot.Orientation);
            robot.ExecuteInstruction("R", world);
            Assert.Equal('N', robot.Orientation);
        }

        [Fact]
        public void Robot_ShouldMoveForwardCorrectly()
        {
            var world = CreateWorld();
            var robot = new Robot(1, 1, 'N');
            robot.ExecuteInstruction("F", world);
            Assert.Equal(1, robot.X);
            Assert.Equal(2, robot.Y);

            robot.Orientation = 'E';
            robot.ExecuteInstruction("F", world);
            Assert.Equal(2, robot.X);
            Assert.Equal(2, robot.Y);

            robot.Orientation = 'S';
            robot.ExecuteInstruction("F", world);
            Assert.Equal(2, robot.X);
            Assert.Equal(1, robot.Y);

            robot.Orientation = 'W';
            robot.ExecuteInstruction("F", world);
            Assert.Equal(1, robot.X);
            Assert.Equal(1, robot.Y);
        }
    }
}
