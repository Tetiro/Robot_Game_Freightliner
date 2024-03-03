using Robot_Game_Freightliner.Interfaces.Pieces;
using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Models.Pieces
{
    public class BoardPiece : IBoardPiece
    {
        protected Position _position;
        protected bool _piecePlacedOnGrid = false;

        public virtual void PlacePieceOnGrid(int x, int y)
        {
            PlacePieceOnGrid(new Position(x, y));
        }
        public virtual void PlacePieceOnGrid(Position position)
        {
            SetPosition(position);
            _piecePlacedOnGrid = true;
        }
        public virtual void SetPosition(int x, int y)
        {
            SetPosition(new Position(x, y));
        }
        public virtual void SetPosition(Position position)
        {
            _position = position;
        }
        public Position GetPosition()
        {
            return _position;
        }
        public bool CheckPieceIsPlaced()
        {
            return _piecePlacedOnGrid;
        }

        public virtual char GetPieceCharacter()
        {
            return ' ';
        }
    }
}
