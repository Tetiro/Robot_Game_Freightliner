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
        public override void SetupBoard(Dimensions dimensions, IEnumerable<BoardPiece> boardPieces = null)
        {
            Robot robot = new Robot();

            boardPieces = boardPieces ?? new List<BoardPiece>();
            List<BoardPiece> piecesList = boardPieces.ToList();
            piecesList.Add(robot);

            _board.ClearGrid();
            _board.SetupGrid(dimensions, piecesList);
        }
        public override void OnInstruction(string instruction)
        {
            if (IsCommandValid(instruction))
            {
                ProcessInstruction(instruction);
            }
        }
        public override void ProcessInstruction(string instruction)
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
                return this.IsCommandValid(instructionParts);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error in {nameof(IsCommandValid)}: {ex.Message}");
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
