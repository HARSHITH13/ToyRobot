using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator;
using FluentAssertions;

namespace ToyRobotTest
{
    public class DirectionTest
    {
        [Theory]
        [InlineData(Direction.North, Direction.West)]
        [InlineData(Direction.East, Direction.North)]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.West, Direction.South)]
        public void Rotate_robot_Left(string before, string after)
        {
            var toyRobot = new ToyRobot();
            toyRobot.Place(1, 1, before);

            toyRobot.Left();

            toyRobot.Facing.Should().Be(after);
        }

        [Theory]
        [InlineData(Direction.North, Direction.East)]
        [InlineData(Direction.East, Direction.South)]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.West, Direction.North)]
        public void Rotate_robot_Right(string before, string after)
        {
            var toyRobot = new ToyRobot();
            toyRobot.Place(1, 1, before);

            toyRobot.Right();

            toyRobot.Facing.Should().Be(after);
        }
    }
}
