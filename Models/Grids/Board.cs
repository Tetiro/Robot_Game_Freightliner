using Robot_Game_Freightliner.Interfaces.Grids;
using Robot_Game_Freightliner.Models.Pieces;
using Robot_Game_Freightliner.Models.Utils;
using System.Text;

namespace Robot_Game_Freightliner.Models.Grids
{
    public class Board : IGrid
    {
        private IEnumerable<BoardPiece> _piecesOnBoard = new List<BoardPiece>();
        private Dimensions _dimensions;

        public virtual void SetupGrid(int width, int height, IEnumerable<BoardPiece> boardPieces = null)
        {
            SetupGrid(new Dimensions(width, height), boardPieces);
        }
        public virtual void SetupGrid(Dimensions dimensions, IEnumerable<BoardPiece> boardPieces = null)
        {
            ClearGrid();
            _dimensions = dimensions;
            _piecesOnBoard = _piecesOnBoard.Concat(boardPieces).ToList();
        }
        public virtual void ClearGrid()
        {
            _piecesOnBoard.ToList().Clear();
        }
        public virtual void PrintGrid()
        {
            string rowLine = new string('-', (_dimensions.Width * 2) + 1);
            Console.WriteLine(rowLine);

            for(int r = _dimensions.Height - 1; r >= 0; r--)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append($"|");

                for (int c = 0; c < _dimensions.Width; c++)
                {
                    BoardPiece piece = _piecesOnBoard.FirstOrDefault(p =>
                    {
                        Position position = p.GetPosition();
                        return position != null && c == position.X && r == position.Y;
                    });
                    builder.Append($"{ (piece != null ? piece.GetPieceCharacter() : ' ') }|");
                }
                Console.WriteLine(builder.ToString());
                Console.WriteLine(rowLine);
            }
        }
        public Dimensions GetDimensions()
        {
            return _dimensions;
        }

        public IEnumerable<BoardPiece> GetPieces()
        {
            return _piecesOnBoard;
        }
    }
}
