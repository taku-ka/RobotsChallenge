using System.Collections.Generic;
using System.Text;
using Challenge.Command;
using Challenge.Interface;
using Challenge.Models;

namespace Challenge.Service

{
    public class RobotService
    {
        private readonly MarsSurface _marsSurface;
        private readonly Dictionary<char, IMoveCommand> _moveCommand;

        public RobotService(MarsSurface marsSurface)
        {
            _marsSurface = marsSurface;
            _moveCommand = new Dictionary<char, IMoveCommand>
                {
                    { 'L', new LeftCommand() },
                    { 'R', new RightCommand() },
                    { 'F', new ForwardCommand() }
                };
        }

        public string MovePosition(RobotPosition robotPosition, string robotInstructions)
        {

            var position = robotPosition;
            bool isLost = false;


            foreach (var instruction in robotInstructions)
            {
                try
                {
                    if (_moveCommand.ContainsKey(instruction))
                    {
                        _moveCommand[instruction].MovePosition(position, _marsSurface);
                    }
                }
                catch (InvalidOperationException)
                {
                    isLost = true;
                    break;
                }
            }

            var result = new StringBuilder($"{position.XPos} {position.YPos} {position.Direction}");


            if (isLost) result.Append(" LOST");


            return result.ToString();
        }
    }
}