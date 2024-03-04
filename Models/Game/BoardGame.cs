using Robot_Game_Freightliner.Interfaces.Games;
using Robot_Game_Freightliner.Interfaces.Grids;
using Robot_Game_Freightliner.Models.Grids;
using Robot_Game_Freightliner.Models.Pieces;
using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Models.Games
{
    /// <summary>
    /// This class contains the properties and methods for the behaviour of a Board Game
    /// </summary>
    public class BoardGame : IGame
    {
        protected IGrid _board;

        public BoardGame()
        {
            _board = new Board();
        }

        /// <summary>
        /// This sets up the board using two integer parameters and an optional collection of BoardPiece objects
        /// </summary>
        public virtual void SetupBoard(int width, int height, IEnumerable<BoardPiece> boardPieces = null)
        {
            SetupBoard(new Dimensions(width, height), boardPieces);
        }

        /// <summary>
        /// This sets up the board using a Dimensions parameter and an optional collection of BoardPiece objects
        /// </summary>
        public virtual void SetupBoard(Dimensions dimensions, IEnumerable<BoardPiece> boardPieces = null)
        {
            _board.SetupGrid(dimensions, boardPieces);
        }

        /// <summary>
        /// This method is a virtual method to be overriden with a child class' behaviour
        /// </summary>
        public virtual void OnInstruction(string instruction)
        {

        }

        /// <summary>
        /// This method prints the grid and its piece on the console output
        /// </summary>
        public virtual void DisplayGame()
        {
            _board.PrintGrid();
        }

        /// <summary>
        /// This method returns the dimensions of the board
        /// </summary>
        public virtual Dimensions GetDimensions()
        {
            return _board.GetDimensions();
        }

        /// <summary>
        /// This method returns the pieces on the board
        /// </summary>
        public virtual IEnumerable<BoardPiece> GetPieces()
        {
            return _board.GetPieces();
        }
    }
}
