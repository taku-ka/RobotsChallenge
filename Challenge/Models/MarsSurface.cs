
namespace Challenge.Models
{
    public class MarsSurface
    {
        public int XMax { get; }
        public int YMax { get; }
        private readonly HashSet<(int, int, Direction)> scents = new();

        public MarsSurface(int xMax, int yMax)
        {
            XMax = xMax;
            YMax = yMax;
        }

        public bool IsOffMarsSurface(int xPos, int yPos) => xPos < 0 || yPos < 0 || xPos > XMax || yPos > YMax;

        public void AddScent(RobotPosition pos) => scents.Add((pos.XPos, pos.YPos, pos.Direction));

        public bool HasScent(RobotPosition pos) => scents.Contains((pos.XPos, pos.YPos, pos.Direction));
    }
}