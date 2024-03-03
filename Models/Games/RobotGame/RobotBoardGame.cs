using Robot_Game_Freightliner.Interfaces.Games;
using Robot_Game_Freightliner.Interfaces.Grids;
using Robot_Game_Freightliner.Interfaces.Pieces;
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
            Robot robot = new Robot();

            _board.ClearGrid();
            boardPieces = boardPieces ?? new List<BoardPiece>();
            boardPieces.ToList().Add(robot);
            _board.SetupGrid(dimensions, boardPieces);
        }
        public void OnInstruction(string instruction)
        {
            if (IsCommandValid(instruction))
            {
                ProcessInstruction(instruction);
            }
        }
        public new void ProcessInstruction(string instruction)
        {
            if (IsCommandValid(instruction))
            {
                this.OnProcessInstruction(instruction);
            }
        }

        public bool IsCommandValid(string instruction)
        {
            string[] instructionParts = instruction.Split(' ');
            RobotGameInstructions command;

            try
            {
                if (Enum.TryParse(instructionParts[0], out command))
                {
                    return this.IsCommandValid(instructionParts);
                }
                else
                {
                    //TO ADD IN hour 3
                }
            }
            catch (Exception ex)
            {
                //TO ADD IN hour 3
            }

            return false;
        }

        public Robot GetRobot()
        {
            BoardPiece robot = _board.GetPieces().FirstOrDefault(x => x.GetType() == typeof(Robot));
            return robot != null ? (Robot)robot : null;
        }
    }
}
