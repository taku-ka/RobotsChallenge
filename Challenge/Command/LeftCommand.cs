using Challenge.Interface;
using Challenge.Models;

namespace Challenge.Command
{
    public class LeftCommand : IMoveCommand
    {
        public void MovePosition(RobotPosition robotPosition, MarsSurface marsSurface)
        {
            robotPosition.Direction = robotPosition.Direction switch
            {
                Direction.N => Direction.W,
                Direction.W => Direction.S,
                Direction.S => Direction.E,
                Direction.E => Direction.N,
                _ => robotPosition.Direction
            };
        }
    }
}