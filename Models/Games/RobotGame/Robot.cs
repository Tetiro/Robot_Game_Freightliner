using Robot_Game_Freightliner.Interfaces.Pieces;
using Robot_Game_Freightliner.Models.Pieces;
using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Models.Games.RobotGame
{
    public class Robot : ControlablePiece, IControlablePiece
    {
        private Direction _direction = Direction.Unknown;

        public void ProcessInstruction(string instruction)
        {
            //TO ADD IN HOUR 2
        }
    }
}
