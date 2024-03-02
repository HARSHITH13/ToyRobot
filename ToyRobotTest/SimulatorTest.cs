using FakeItEasy;
using ToyRobotSimulator;

namespace ToyRobotTest
{
    public class SimulatorTest
    {
        [Fact]
        public void Test_Place_Command()
        {
            ToyRobot toyRobot = new ToyRobot();
            Simulator simulator = new Simulator(toyRobot);
            simulator.Execute("PLACE 0,0,NORTH");
            simulator.Execute("MOVE");
            Assert.Equal("0,1,NORTH", toyRobot.Report());

            simulator.Execute("PLACE 3,4,SOUTH");
            simulator.Execute("MOVE");
            Assert.Equal("3,3,SOUTH",toyRobot.Report());
        }

        [Fact]
        public void Test_Move_Command()
        {
            ToyRobot toyRobot = new ToyRobot();
            Simulator simulator = new Simulator(toyRobot);
            simulator.Execute("PLACE 0,0,NORTH");
            simulator.Execute("MOVE");
            Assert.Equal("0,1,NORTH", toyRobot.Report());
        }

        [Fact]
        public void Test_Left_Command()
        {
            ToyRobot toyRobot = new ToyRobot();
            Simulator simulator = new Simulator(toyRobot);
            simulator.Execute("PLACE 2,3,EAST");
            simulator.Execute("LEFT");
            Assert.Equal("2,3,NORTH", toyRobot.Report());
        }

        [Fact]
        public void Test_Right_Command()
        {
            ToyRobot toyRobot = new ToyRobot();
            Simulator simulator = new Simulator(toyRobot);
            simulator.Execute("PLACE 1,2,SOUTH");
            simulator.Execute("RIGHT");
            Assert.Equal("1,2,WEST", toyRobot.Report());
        }

        [Fact]
        public void Test_Report_Command()
        {
            ToyRobot toyRobot = new ToyRobot();
            Simulator simulator = new Simulator(toyRobot);
            simulator.Execute("PLACE 1,2,SOUTH");
            simulator.Execute("REPORT");
            Assert.Equal("1,2,SOUTH", toyRobot.Report());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("test")]
        [InlineData("PLACE x,3,NORTH")]
        [InlineData("PLACE 4,x,EAST")]
        [InlineData("PLACE 54454545,3e3221,SOUTH")]
        public void Ignore_Invalid_Commnads(string cmd) {
            ToyRobot toyRobot = A.Fake<ToyRobot>();
            Simulator simulator = new Simulator(toyRobot);            
            simulator.Execute(cmd);

            A.CallTo(() => toyRobot.Place(A<int>.Ignored, A<int>.Ignored, A<string>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => toyRobot.Move()).MustNotHaveHappened();
            A.CallTo(() => toyRobot.Left()).MustNotHaveHappened();
            A.CallTo(() => toyRobot.Right()).MustNotHaveHappened();
            A.CallTo(() => toyRobot.Report()).MustNotHaveHappened();

        }

    }
}
