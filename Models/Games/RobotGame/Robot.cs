using Robot_Game_Freightliner.Interfaces.Pieces;
using Robot_Game_Freightliner.Models.Pieces;
using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Models.Games.RobotGame
{
    public class Robot : ControlablePiece, IControlablePiece
    {
        private Direction _direction = Direction.Unknown;

        public Direction GetDirection()
        {
            return _direction;
        }

        public void SetDirection(Direction direction)
        {
            _direction = direction;
        }

        public override char GetPieceCharacter()
        {
            return 'R';
        }
    }
}
