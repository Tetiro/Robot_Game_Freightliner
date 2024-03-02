using Robot_Game_Freightliner.Interfaces.Pieces;

namespace Robot_Game_Freightliner.Models.Pieces
{
    public class MoveablePiece : BoardPiece, IMoveablePiece
    {
        public void MoveRelativeToPosition(int x, int y)
        {
            MoveRelativeToPosition(new Position(x, y));
        }
        public void MoveRelativeToPosition(Position position)
        {
            SetPosition(new Position(_position.X + position.X, _position.Y + position.Y));
        }
    }
}
