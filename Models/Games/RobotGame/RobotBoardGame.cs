using Robot_Game_Freightliner.Interfaces.Games;
using Robot_Game_Freightliner.Interfaces.Grids;
using Robot_Game_Freightliner.Models.Game;
using Robot_Game_Freightliner.Models.Games.RobotGame;
using Robot_Game_Freightliner.Models.Grids;
using Robot_Game_Freightliner.Models.Pieces;
using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Models.Games
{
    public class RobotBoardGame : BoardGame
    {
        public void SetupBoard(Dimensions dimensions, IEnumerable<BoardPiece> boardPieces = null)
        {
            var robot = new Robot();

            _board.ClearGrid();
            boardPieces = boardPieces ?? new List<BoardPiece>();
            boardPieces.ToList().Add(robot);
            _board.SetupGrid(dimensions, boardPieces);
        }
        public void OnInstruction(string instruction)
        {
            //TO ADD in hour 2
        }
        public void ProcessInstruction(string instruction)
        {
            //TO ADD in hour 2
        }
    }
}
