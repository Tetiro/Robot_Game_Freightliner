using Robot_Game_Freightliner.Interfaces.Pieces;
using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Models.Pieces
{
    /// <summary>
    /// This class contains the properties and methods for the behaviour of a Board Piece
    /// </summary>
    public class BoardPiece : IBoardPiece
    {
        protected Position _position;
        protected bool _piecePlacedOnGrid = false;

        /// <summary>
        /// This method places a piece on the grid using two integer parameters
        /// </summary>
        public virtual void PlacePieceOnGrid(int x, int y)
        {
            PlacePieceOnGrid(new Position(x, y));
        }

        /// <summary>
        /// This method places a piece on the grid using a Position parameter
        /// </summary>
        public virtual void PlacePieceOnGrid(Position position)
        {
            SetPosition(position);
            _piecePlacedOnGrid = true;
        }

        /// <summary>
        /// This method sets the position of the piece using two integer parameters
        /// </summary>
        public virtual void SetPosition(int x, int y)
        {
            SetPosition(new Position(x, y));
        }

        /// <summary>
        /// This method sets the position of the piece using a Position parameter
        /// </summary>
        public virtual void SetPosition(Position position)
        {
            _position = position;
        }

        /// <summary>
        /// This method returns the Position of the piece
        /// </summary>
        public Position GetPosition()
        {
            return _position;
        }

        /// <summary>
        /// This method returns if the piece has been placed on the grid
        /// </summary>
        public bool CheckPieceIsPlaced()
        {
            return _piecePlacedOnGrid;
        }

        /// <summary>
        /// This method returns a character for displaying
        /// </summary>
        public virtual char GetPieceCharacter()
        {
            return ' ';
        }
    }
}
