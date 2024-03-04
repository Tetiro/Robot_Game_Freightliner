using Robot_Game_Freightliner.Interfaces.Pieces;
using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Models.Pieces
{
    /// <summary>
    /// This class contains the properties and methods for the behaviour of a Moveable Piece
    /// </summary>
    public class MoveablePiece : BoardPiece, IMoveablePiece
    {
        /// <summary>
        /// This method moves the piece to a new position relative to its original placement using integer parameters
        /// </summary>
        public virtual void MoveRelativeToPosition(int x, int y)
        {
            MoveRelativeToPosition(new Position(x, y));
        }

        /// <summary>
        /// This method moves the piece to a new position relative to its original placement using a Position parameter
        /// </summary>
        public virtual void MoveRelativeToPosition(Position position)
        {
            SetPosition(new Position(_position.X + position.X, _position.Y + position.Y));
        }
    }
}
