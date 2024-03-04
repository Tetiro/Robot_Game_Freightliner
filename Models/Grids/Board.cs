using Robot_Game_Freightliner.Interfaces.Grids;
using Robot_Game_Freightliner.Models.Pieces;
using Robot_Game_Freightliner.Models.Utils;
using System.Text;

namespace Robot_Game_Freightliner.Models.Grids
{
    /// <summary>
    /// This class contains the properties and methods for the behaviour of a Board
    /// </summary>
    public class Board : IGrid
    {
        private IEnumerable<BoardPiece> _piecesOnBoard = new List<BoardPiece>();
        private Dimensions _dimensions;

        /// <summary>
        /// This method sets up the grid using two specified integers and an optional collection of BoardPiece objects
        /// </summary>
        public virtual void SetupGrid(int width, int height, IEnumerable<BoardPiece> boardPieces = null)
        {
            SetupGrid(new Dimensions(width, height), boardPieces);
        }

        /// <summary>
        /// This method sets up the grid using the specified dimensions and an optional collection of BoardPiece objects
        /// </summary>
        public virtual void SetupGrid(Dimensions dimensions, IEnumerable<BoardPiece> boardPieces = null)
        {
            ClearGrid();
            _dimensions = dimensions;
            _piecesOnBoard = _piecesOnBoard.Concat(boardPieces).ToList();
        }

        /// <summary>
        /// This method clears the grid
        /// </summary>
        public virtual void ClearGrid()
        {
            _piecesOnBoard.ToList().Clear();
        }

        /// <summary>
        /// This method prints the grid to a console output
        /// </summary>
        public virtual void PrintGrid()
        {
            string rowLine = new string('-', (_dimensions.Width * 2) + 1); //Produces the dashes between each row
            Console.WriteLine(rowLine);

            for(int r = _dimensions.Height - 1; r >= 0; r--) //Loops all rows in reverse order
            {
                StringBuilder builder = new StringBuilder();
                builder.Append($"|");

                for (int c = 0; c < _dimensions.Width; c++) //Loops all columns in order
                {
                    //The logic below will attempt to find a piece to display on instead of a space character
                    //Based on the current position on the grid

                    BoardPiece piece = _piecesOnBoard.FirstOrDefault(p =>
                    {
                        Position position = p.GetPosition();
                        return position != null && c == position.X && r == position.Y;
                    });
                    builder.Append($"{ (piece != null ? piece.GetPieceCharacter() : ' ') }|");
                }

                Console.WriteLine(builder.ToString()); //Outputs the row of characters
                Console.WriteLine(rowLine); //Outputs the row divider
            }
        }

        /// <summary>
        /// This method returns the dimensions of the board
        /// </summary>
        public Dimensions GetDimensions()
        {
            return _dimensions;
        }

        /// <summary>
        /// This method returns the pieces on the board
        /// </summary>
        public IEnumerable<BoardPiece> GetPieces()
        {
            return _piecesOnBoard;
        }
    }
}
