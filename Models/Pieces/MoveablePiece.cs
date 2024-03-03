using Robot_Game_Freightliner.Interfaces.Pieces;
using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Models.Pieces
{
    public class MoveablePiece : BoardPiece, IMoveablePiece
    {
        public virtual void MoveRelativeToPosition(int x, int y)
        {
            MoveRelativeToPosition(new Position(x, y));
        }
        public virtual void MoveRelativeToPosition(Position position)
        {
            SetPosition(new Position(_position.X + position.X, _position.Y + position.Y));
        }
    }
}
