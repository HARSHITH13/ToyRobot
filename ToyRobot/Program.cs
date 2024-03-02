using System;

namespace ToyRobotSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ToyRobot toyRobot = new ToyRobot();
            Simulator simulator = new Simulator(toyRobot);

            while (true)
            {
                string input = Console.ReadLine();
                simulator.Execute(input);
            }
        }
    }
}
