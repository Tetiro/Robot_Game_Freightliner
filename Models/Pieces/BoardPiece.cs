using Robot_Game_Freightliner.Interfaces.Pieces;
using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Models.Pieces
{
    public class BoardPiece : IBoardPiece
    {
        protected Position _position;
        protected bool _piecePlacedOnGrid = false;

        public void PlacePieceOnGrid(int x, int y)
        {
            PlacePieceOnGrid(new Position(x, y));
        }
        public void PlacePieceOnGrid(Position position)
        {
            SetPosition(position);
            _piecePlacedOnGrid = false;
        }
        public void SetPosition(int x, int y)
        {
            SetPosition(new Position(x, y));
        }
        public void SetPosition(Position position)
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
    }
}
