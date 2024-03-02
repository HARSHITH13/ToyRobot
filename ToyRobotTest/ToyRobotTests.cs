using FluentAssertions;
using ToyRobotSimulator;

namespace ToyRobotTest
{
    public class ToyRobotTests
    {
        [Fact]
        public void TestPlace()
        {
            ToyRobot toyRobot = new ToyRobot();
            toyRobot.Place(1, 2, "NORTH");
            Assert.Equal(1, toyRobot.X);
            Assert.Equal(2, toyRobot.Y);
            Assert.Equal("NORTH", toyRobot.Facing);
        }

        [Fact]
        public void Discard_Report_cmd_when_robot_not_placed_on_the_table()
        {
            ToyRobot toyRobot = new ToyRobot();

            var result = toyRobot.Report();

            result.Should().Be(null);
        }

        [Fact]
        public void Discard_Move_cmd_when_robot_not_placed_on_the_table()
        {
            ToyRobot toyRobot = new ToyRobot();

            toyRobot.Move();

            toyRobot.X.Should().Be(null);
            toyRobot.Y.Should().Be(null);
            toyRobot.Facing.Should().Be(null);
        }

        [Fact]
        public void Discard_Left_cmd_when_robot_not_placed_on_the_table()
        {
            ToyRobot toyRobot = new ToyRobot();

            toyRobot.Left();

            toyRobot.X.Should().Be(null);
            toyRobot.Y.Should().Be(null);
            toyRobot.Facing.Should().Be(null);
        }

        [Fact]
        public void Discard_Right_command_when_robot_not_placed_on_the_table()
        {
            ToyRobot toyRobot = new ToyRobot();

            toyRobot.Right();

            toyRobot.X.Should().Be(null);
            toyRobot.Y.Should().Be(null);
            toyRobot.Facing.Should().Be(null);
        }
    }
}