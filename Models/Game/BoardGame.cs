using Robot_Game_Freightliner.Interfaces.Games;
using Robot_Game_Freightliner.Interfaces.Grids;
using Robot_Game_Freightliner.Models.Grids;
using Robot_Game_Freightliner.Models.Pieces;
using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Models.Games
{
    public class BoardGame : IGame
    {
        protected IGrid _board;

        public BoardGame()
        {
            _board = new Board();
        }
        public virtual void SetupBoard(int width, int height, IEnumerable<BoardPiece> boardPieces = null)
        {
            SetupBoard(new Dimensions(width, height), boardPieces);
        }
        public virtual void SetupBoard(Dimensions dimensions, IEnumerable<BoardPiece> boardPieces = null)
        {
            _board.SetupGrid(dimensions, boardPieces);
        }
        public virtual void OnInstruction(string instruction)
        {

        }

        public virtual void DisplayGame()
        {
            _board.PrintGrid();
        }

        public virtual Dimensions GetDimensions()
        {
            return _board.GetDimensions();
        }

        public virtual IEnumerable<BoardPiece> GetPieces()
        {
            return _board.GetPieces();
        }
    }
}
