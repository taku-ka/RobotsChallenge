namespace Challenge.Models
{
    public class RobotPosition
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public Direction Direction { get; set; }

        public RobotPosition(int xPos, int yPos, Direction direction)
        {
            XPos = xPos;
            YPos = yPos;
            Direction = direction;
        }

        public RobotPosition Clone() => new RobotPosition(XPos, YPos, Direction);
    }
}