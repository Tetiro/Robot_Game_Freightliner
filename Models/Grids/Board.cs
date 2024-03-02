using Robot_Game_Freightliner.Interfaces.Grids;
using Robot_Game_Freightliner.Models.Pieces;
using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Models.Grids
{
    public class Board : IGrid
    {
        private IEnumerable<BoardPiece> _piecesOnBoard = new List<BoardPiece>();
        private Dimensions _dimensions;

        public void SetupGrid(int width, int height, IEnumerable<BoardPiece> boardPieces = null)
        {
            SetupGrid(new Dimensions(width, height), boardPieces);
        }
        public void SetupGrid(Dimensions dimensions, IEnumerable<BoardPiece> boardPieces = null)
        {
            ClearGrid();
            _dimensions = dimensions;
            _piecesOnBoard.ToList().AddRange(boardPieces);
        }
        public void ClearGrid()
        {
            try
            {
                _piecesOnBoard.ToList().Clear();
            }
            catch (Exception ex)
            {

            }
        }
        public Dimensions GetDimensions()
        {
            return _dimensions;
        }
    }
}
