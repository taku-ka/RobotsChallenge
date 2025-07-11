// See https://aka.ms/new-console-template for more information

using Challenge.Models;
using Challenge.Service;

namespace Challenge
{

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Send instructions to Robot in Mars
            var marsSurface = new MarsSurface(5, 3);
            var robotService = new RobotService(marsSurface);

            MoveRobot(robotService, new RobotPosition(1, 1, Direction.E), "RFRFRFRF");
            MoveRobot(robotService, new RobotPosition(3, 2, Direction.N), "FRRFLLFFRRFLL");
            MoveRobot(robotService, new RobotPosition(0, 3, Direction.W), "LLFFFLFLFL");
            #endregion
        }

        static void MoveRobot(RobotService robotService, RobotPosition robotPosition, string commands)
        {
            try
            {
                #region Check command rules
                if (commands.Length > 100)
                {
                    throw new ArgumentException("Move instruction should not exceed 100 characters");
                }

                if (robotPosition.XPos < 0 || robotPosition.XPos > 50)
                {
                    throw new ArgumentException($"Surface MaxX must have value in range from 1 to 50");
                }
                if (robotPosition.YPos < 0 || robotPosition.YPos > 50)
                {
                    throw new ArgumentException($"Surface MaxY must have value in range from 1 to 50");
                }
                #endregion


                var result = robotService.MovePosition(robotPosition, commands);
                Console.WriteLine(result);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}