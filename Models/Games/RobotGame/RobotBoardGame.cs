using Robot_Game_Freightliner.Models.Games.RobotGame;
using Robot_Game_Freightliner.Models.Pieces;
using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Models.Games
{
    public class RobotBoardGame : BoardGame
    {
        /// <summary>
        /// This method overrides the BoardGame's SetupBoard to create the Robot and add it to the board pieces
        /// </summary>
        public override void SetupBoard(int width, int height, IEnumerable<BoardPiece> boardPieces = null)
        {
            SetupBoard(new Dimensions(width, height));
        }

        /// <summary>
        /// This method overrides the BoardGame's SetupBoard to create the Robot and add it to the board pieces
        /// </summary>
        public override void SetupBoard(Dimensions dimensions, IEnumerable<BoardPiece> boardPieces = null)
        {
            Robot robot = new Robot();

            boardPieces = boardPieces ?? new List<BoardPiece>();
            List<BoardPiece> piecesList = boardPieces.ToList();
            piecesList.Add(robot);

            base.SetupBoard(dimensions, piecesList);
        }

        /// <summary>
        /// This method validates and processes a command based on the Robot BoardGame
        /// </summary>
        public override void OnInstruction(string instruction)
        {
            if (this.IsCommandValid(instruction))
            {
                this.OnProcessInstruction(instruction);
            }
        }

        /// <summary>
        /// This method retrieves the first instance of a Robot class
        /// </summary>
        public Robot GetRobot()
        {
            BoardPiece robot = _board.GetPieces().FirstOrDefault(x => x.GetType() == typeof(Robot));
            return robot != null ? (Robot)robot : null;
        }
    }
}
