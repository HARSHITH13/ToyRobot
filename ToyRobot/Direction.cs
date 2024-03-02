using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public static class Direction
    {
        public const string North = "NORTH";
        public const string East = "EAST";
        public const string South = "SOUTH";
        public const string West = "WEST";

        public static bool IsValid(this string direction)
            => direction == North || direction == East || direction == South || direction == West;

        public static string RotateLeft(this string direction)
        {
            return direction switch
            {
                North => West,
                West => South,
                South => East,
                East => North,
                _ => direction
            };
        }

        public static string RotateRight(this string direction)
        {
            return direction switch
            {
                North => East,
                East => South,
                South => West,
                West => North,
                _ => direction
            };
        }
    }
}
