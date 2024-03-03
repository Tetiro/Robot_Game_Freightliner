using Robot_Game_Freightliner.Interfaces.Pieces;
using Robot_Game_Freightliner.Models.Utils;
using Robot_Game_Freightliner.Utilities;

namespace Robot_Game_Freightliner.Models.Games.RobotGame
{
    public static class RobotGameExtensions
    {

        public static bool IsCommandValid(this RobotBoardGame boardGame, string[] instructionParts)
        {
            Dictionary<RobotGameInstructions, Func<RobotBoardGame, Robot, string[], bool>> validationFunctions
               = new Dictionary<RobotGameInstructions, Func<RobotBoardGame, Robot, string[], bool>>()
               {
                   [RobotGameInstructions.Print] = CheckPrintValid,
                   [RobotGameInstructions.Turn] = CheckTurnCommandValid,
                   [RobotGameInstructions.Move] = CheckPlaceMoveValid,
                   [RobotGameInstructions.Place] = CheckPlaceCommandValid
               };

            try
            {
                Robot robot = boardGame.GetRobot();

                if (Enum.TryParse(instructionParts[0].ToCamelCase(), out RobotGameInstructions command) && robot != null)
                {
                    return (validationFunctions.ContainsKey(command)) ? validationFunctions[command](boardGame, robot, instructionParts) : false;
                }
                else
                {
                    Console.WriteLine(robot != null ? "Invalid instruction" : "There is no robot on the board!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error in {nameof(IsCommandValid)}: {ex.Message}");
                return false;
            }
        }

        public static bool OnProcessInstruction(this RobotBoardGame boardGame, string instruction)
        {
            string[] instructionParts = instruction.Split(' ');

            Robot robot = boardGame.GetRobot();

            if (Enum.TryParse(instructionParts[0].ToCamelCase(), out RobotGameInstructions command) && robot != null)
            {
                try
                {
                    switch (command)
                    {
                        case RobotGameInstructions.Display:
                            {
                                boardGame.DisplayGame();
                            }; break;
                        default:
                            {
                                robot.OnInstruction(instruction);
                            }; break;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error in {nameof(OnProcessInstruction)}: {ex.Message}");
                    return false;
                }
            }
            else
            {
                Console.WriteLine(robot != null ? "Invalid instruction" : "There is no robot on the board!");
                return false;
            }
        }

        public static bool IsNewPositionValid(this RobotBoardGame boardGame, Position position)
        {
            Dimensions dimensions = boardGame.GetDimensions();
            return Enumerable.Range(0, dimensions.Width).Contains(position.X) && Enumerable.Range(0, dimensions.Height).Contains(position.Y);
        }

        public static bool CheckTurnCommandValid(this RobotBoardGame boardGame, Robot robot, string[] instructionParts)
        {
            if (instructionParts.Count() < 2 || !instructionParts[1].ToCamelCase().IsDirectionValid())
            {
                Console.WriteLine("No valid direction was provided! Your choices are North, South, East and West");
            }

            return robot.CheckPieceIsPlaced() 
                && instructionParts.Count() > 1 
                && instructionParts[1].ToCamelCase().IsDirectionValid();
        }

        public static bool CheckPlaceCommandValid(this RobotBoardGame boardGame, Robot robot, string[] instructionParts)
        {
            if (robot.CheckPieceIsPlaced())
            {
                Console.WriteLine("The robot is already on the board!");
            }

            return !robot.CheckPieceIsPlaced() && instructionParts.Count() > 3 
                 && instructionParts[3].ToCamelCase().IsDirectionValid()
                 && instructionParts[1].IsCoordinateValid()
                 && instructionParts[2].IsCoordinateValid()
                 && IsNewPositionValid(boardGame, new Position(instructionParts[2].GetCoordinate(), instructionParts[1].GetCoordinate()));
        }

        public static bool CheckPlaceMoveValid(this RobotBoardGame boardGame, Robot robot, string[] instructionParts)
        {
            var checkPlacementAndDirection = robot.CheckPieceIsPlaced() && robot.GetDirection() != Direction.Unknown;
            if (!checkPlacementAndDirection)
            {
                Console.WriteLine("Error: First instruction must be PLACE");
                return false;
            }

            var newPositionCheck = boardGame.IsNewPositionValid(robot.GetNewPosition());
            if (!newPositionCheck)
            {
                Console.WriteLine("Stop! Going to fall!");
            }

            return newPositionCheck;
        }

        public static bool CheckPrintValid(this RobotBoardGame boardGame, Robot robot, string[] instructionParts)
        {
            return robot.CheckPieceIsPlaced();
        }
    }
}
