using Robot_Game_Freightliner.Interfaces.Games;
using Robot_Game_Freightliner.Interfaces.Grids;
using Robot_Game_Freightliner.Models.Game;
using Robot_Game_Freightliner.Models.Grids;
using Robot_Game_Freightliner.Models.Pieces;
using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Models.Games
{
    public class BoardGame : IGame
    {
        protected IGrid _board;
        protected GameStatus _gameStatus = GameStatus.NotStarted;

        public BoardGame()
        {
            _board = new Board();
        }

        public virtual void StartGame()
        {
            List<GameStatus> acceptableStatuses = new List<GameStatus>() { GameStatus.NotStarted, GameStatus.Stopped };
            _gameStatus = acceptableStatuses.Contains(_gameStatus) ? GameStatus.Started : _gameStatus;
        }
        public virtual void StopGame()
        {
            List<GameStatus> acceptableStatuses = new List<GameStatus>() { GameStatus.Started };
            _gameStatus = acceptableStatuses.Contains(_gameStatus) ? GameStatus.Stopped : _gameStatus;
        }
        public GameStatus GetStatus()
        {
            return _gameStatus;
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
        public virtual void ProcessInstruction(string instruction)
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
