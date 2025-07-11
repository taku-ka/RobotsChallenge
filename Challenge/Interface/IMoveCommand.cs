using Challenge.Models;

namespace Challenge.Interface
{
    public interface IMoveCommand
    {
        void MovePosition(RobotPosition robotPosition, MarsSurface marsSurface);
    }
}