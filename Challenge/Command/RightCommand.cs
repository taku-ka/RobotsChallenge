using Challenge.Interface;
using Challenge.Models;

namespace Challenge.Command
{
    public class RightCommand : IMoveCommand
    {
        public void MovePosition(RobotPosition robotPosition, MarsSurface marsSurface)
        {
            robotPosition.Direction = robotPosition.Direction switch
            {
                Direction.N => Direction.E,
                Direction.E => Direction.S,
                Direction.S => Direction.W,
                Direction.W => Direction.N,
                _ => robotPosition.Direction
            };
        }
    }
}