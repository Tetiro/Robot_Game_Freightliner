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
                    Console.WriteLine(robot != null ? "Invalid user input!" : "There is no robot on the board!");
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
                        case RobotGameInstructions.Place:
                            {
                                Position position = new Position(GetCoordinate(instructionParts[1]), GetCoordinate(instructionParts[2]));
                                robot.PlacePieceOnGrid(position.X, position.Y);
                                robot.SetDirection(GetDirection(instructionParts[3].ToCamelCase()));
                            }; break;
                        case RobotGameInstructions.Turn:
                            {
                                robot.SetDirection(GetDirection(instructionParts[1].ToCamelCase()));
                            }; break;
                        case RobotGameInstructions.Move:
                            {
                                Position position = GetNewRobotPosition(robot);
                                robot.SetPosition(position.X, position.Y);
                            }; break;
                        case RobotGameInstructions.Print:
                            {
                                Console.WriteLine($"{robot.GetPosition().X} {robot.GetPosition().Y} {robot.GetDirection().ToString().ToUpper()}");
                            }; break;
                        case RobotGameInstructions.Display:
                            {
                                boardGame.DisplayGame();
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
                Console.WriteLine(robot != null ? "Invalid user input!" : "There is no robot on the board!");
                return false;
            }
        }

        public static bool CheckRobotIsPlaced(Robot robot)
        {
            return robot.CheckPieceIsPlaced();
        }
        public static bool IsNewPositionValid(this BoardGame boardGame, Position position)
        {
            Dimensions dimensions = boardGame.GetDimensions();
            return Enumerable.Range(0, dimensions.Width).Contains(position.X) && Enumerable.Range(0, dimensions.Height).Contains(position.Y);
        }

        public static bool IsDirectionValid(string valueString)
        {
            return Enum.TryParse(valueString, out Direction value);
        }

        public static bool IsCoordinateValid(string valueString)
        {
            return int.TryParse(valueString, out int value);
        }

        public static Direction GetDirection(string valueString)
        {
            Enum.TryParse(valueString, out Direction value);
            return value;
        }

        public static int GetCoordinate(string valueString)
        {
            int.TryParse(valueString, out int value);
            return value;
        }

        public static bool CheckTurnCommandValid(this BoardGame boardGame, Robot robot, string[] instructionParts)
        {
            if (instructionParts.Count() < 2 || !IsDirectionValid(instructionParts[1].ToCamelCase()))
            {
                Console.WriteLine("No valid direction was provided! Your choices are North, South, East and West");
            }

            return robot.CheckPieceIsPlaced() && instructionParts.Count() > 1 && IsDirectionValid(instructionParts[1].ToCamelCase());
        }

        public static bool CheckPlaceCommandValid(this BoardGame boardGame, Robot robot, string[] instructionParts)
        {
            if (robot.CheckPieceIsPlaced())
            {
                Console.WriteLine("The robot is already on the board!");
            }

            return !robot.CheckPieceIsPlaced() && instructionParts.Count() > 3 && IsDirectionValid(instructionParts[3].ToCamelCase())
                 && IsCoordinateValid(instructionParts[1]) && IsCoordinateValid(instructionParts[2])
                 && IsNewPositionValid(boardGame, new Position(GetCoordinate(instructionParts[1]), GetCoordinate(instructionParts[2])));
        }

        public static bool CheckPlaceMoveValid(this BoardGame boardGame, Robot robot, string[] instructionParts)
        {
            var checkPlacementAndDirection = robot.CheckPieceIsPlaced() && robot.GetDirection() != Direction.Unknown;
            if (!checkPlacementAndDirection)
            {
                Console.WriteLine("Cannot move the robot! It has not been placed yet!");
                return false;
            }

            var newPositionCheck = boardGame.IsNewPositionValid(GetNewRobotPosition(robot));
            if (!newPositionCheck)
            {
                Console.WriteLine("Stop! Going to fall!");
            }

            return newPositionCheck;
        }

        public static Position GetNewRobotPosition(Robot robot)
        {
            Position position = robot.GetPosition();

            switch (robot.GetDirection())
            {
                case Direction.East: return new Position(position.X + 1, position.Y);
                case Direction.West: return new Position(position.X - 1, position.Y);
                case Direction.North: return new Position(position.X, position.Y + 1);
                case Direction.South: return new Position(position.X, position.Y - 1);
                default: return new Position(position.X, position.Y);
            }
        }

        public static bool CheckPrintValid(this BoardGame boardGame, Robot robot, string[] instructionParts)
        {
            return robot.CheckPieceIsPlaced();
        }
    }
}
