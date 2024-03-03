using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Models.Games.RobotGame
{
    public static class RobotGameExtensions
    {

        public static bool IsCommandValid(this RobotBoardGame boardGame, string[] instructionParts)
        {
            Dictionary<RobotGameInstructions, Func<RobotBoardGame, Robot, string[], bool>> validationFunctions 
               = new Dictionary<RobotGameInstructions, Func<RobotBoardGame, Robot, string[], bool>>()
            {
                [RobotGameInstructions.Print] = CheckPlacePrintValid,
                [RobotGameInstructions.Turn] = CheckTurnCommandValid,
                [RobotGameInstructions.Move] = CheckPlaceMoveValid,
                [RobotGameInstructions.Place] = CheckPlaceCommandValid
               };

            try
            {
                Robot robot = boardGame.GetRobot();

                if (Enum.TryParse(instructionParts[0], out RobotGameInstructions command) && robot != null)
                {
                    return (validationFunctions.ContainsKey(command)) ? validationFunctions[command](boardGame, robot, instructionParts) : false;
                }
                else
                {
                    //TO ADD IN hour 3
                    return false;
                }
            }
            catch (Exception ex)
            {
                //TO ADD in hour 3
                return false;
            }
        }

        public static bool OnProcessInstruction(this RobotBoardGame boardGame, string instruction)
        {
            string[] instructionParts = instruction.Split(' ');

            try
            {
                Robot robot = boardGame.GetRobot();

                if (Enum.TryParse(instructionParts[0], out RobotGameInstructions command) && robot != null)
                {
                    try
                    {
                        switch (command)
                        {
                            case RobotGameInstructions.Place:
                                {
                                    Position position = new Position(GetCoordinate(instructionParts[1]), GetCoordinate(instructionParts[2]));
                                    robot.PlacePieceOnGrid(position.X, position.Y);
                                }; break;
                            case RobotGameInstructions.Turn:
                                {
                                    robot.SetDirection(GetDirection(instructionParts[3]));
                                }; break;
                            case RobotGameInstructions.Move:
                                {
                                    Position position = GetNewRobotPosition(robot);
                                    robot.SetPosition(position.X, position.Y);
                                }; break;
                            case RobotGameInstructions.Print:
                                {
                                    //TO ADD in hour 3
                                }; break;
                        }
                    }
                    catch (Exception ex)
                    {
                        //TO ADD in hour 3
                        return false;
                    }
                }
                else
                {
                    //TO ADD IN hour 3
                    return false;
                }
            }
            catch (Exception ex)
            {
                //TO ADD in hour 3
                return false;
            }

            return false;
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
            return robot.CheckPieceIsPlaced() && instructionParts.Count() > 1 && IsDirectionValid(instructionParts[1]);
        }

        public static bool CheckPlaceCommandValid(this BoardGame boardGame, Robot robot, string[] instructionParts)
        {
            return robot.CheckPieceIsPlaced() && instructionParts.Count() > 3 && IsDirectionValid(instructionParts[3])
                 && IsCoordinateValid(instructionParts[1]) && IsCoordinateValid(instructionParts[2])
                 && IsNewPositionValid(boardGame, new Position(GetCoordinate(instructionParts[1]), GetCoordinate(instructionParts[2])));
        }

        public static bool CheckPlaceMoveValid(this BoardGame boardGame, Robot robot, string[] instructionParts)
        {
            return robot.CheckPieceIsPlaced() && robot.GetDirection() != Direction.Unknown && boardGame.IsNewPositionValid(GetNewRobotPosition(robot));
        }

        public static Position GetNewRobotPosition(Robot robot)
        {
            Position position = robot.GetPosition();
            
            switch (robot.GetDirection())
            {
                case Direction.North: return new Position(position.X + 1, position.Y);
                case Direction.South: return new Position(position.X - 1, position.Y);
                case Direction.East: return new Position(position.X, position.Y + 1);
                case Direction.West: return new Position(position.X, position.Y - 1);
                default: return new Position(position.X, position.Y);
            }
        }

        public static bool CheckPlacePrintValid(this BoardGame boardGame, Robot robot, string[] instructionParts)
        {
            return !robot.CheckPieceIsPlaced();
        }
    }
}
