using Challenge.Interface;
using Challenge.Models;

namespace Challenge.Command
{
    public class ForwardCommand : IMoveCommand
    {


        public void MovePosition(RobotPosition robotPosition, MarsSurface marsSurface)
        {
            var next = robotPosition.Clone();
            switch (robotPosition.Direction)
            {
                case Direction.N: next.YPos += 1; break;
                case Direction.E: next.XPos += 1; break;
                case Direction.S: next.YPos -= 1; break;
                case Direction.W: next.XPos -= 1; break;
            }

            if (marsSurface.IsOffMarsSurface(next.XPos, next.YPos))
            {
                if (!marsSurface.HasScent(robotPosition))
                {
                    marsSurface.AddScent(robotPosition);
                    throw new InvalidOperationException("Robot not found");
                }
            }
            else
            {
                robotPosition.XPos = next.XPos;
                robotPosition.YPos = next.YPos;
            }
        }
    }
}