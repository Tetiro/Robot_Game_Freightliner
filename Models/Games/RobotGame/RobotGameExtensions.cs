using Robot_Game_Freightliner.Interfaces.Pieces;
using Robot_Game_Freightliner.Models.Utils;
using Robot_Game_Freightliner.Utilities;

namespace Robot_Game_Freightliner.Models.Games.RobotGame
{
    /// <summary>
    /// This class handles all the extension methods required for the RobotBoardGame class
    /// </summary>
    public static class RobotGameExtensions
    {
        /// <summary>
        /// This method validates the command using a string parameter as the instruction
        /// </summary>
        public static bool IsCommandValid(this RobotBoardGame boardGame, string instruction)
        {
            string[] instructionParts = instruction.Split(' ');

            //This Dictionary collection holds the validation functions based on the Enum key
            Dictionary<RobotGameInstructions, Func<RobotBoardGame, Robot, string[], bool>> validationFunctions
               = new Dictionary<RobotGameInstructions, Func<RobotBoardGame, Robot, string[], bool>>()
               {
                   [RobotGameInstructions.Print] = CheckPrintCommandValid,
                   [RobotGameInstructions.Turn] = CheckTurnCommandValid,
                   [RobotGameInstructions.Move] = CheckMoveCommandValid,
                   [RobotGameInstructions.Place] = CheckPlaceCommandValid
               };

            try
            {
                Robot robot = boardGame.GetRobot(); //Looks for the robot. If it does not exist, we cannot command a robot

                //If the command part of the array is a valid Enum and the robot is valid
                if (Enum.TryParse(instructionParts[0].ToTitleCase(), out RobotGameInstructions command) && robot != null)
                {
                    //Returns either the result of the function or false as it does not exist in the Dictionary. Display is an enum but it is not in the validate Functions
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

        /// <summary>
        /// This method processes the instruction using a string parameter as the function
        /// </summary>
        public static bool OnProcessInstruction(this RobotBoardGame boardGame, string instruction)
        {
            string[] instructionParts = instruction.Split(' ');

            Robot robot = boardGame.GetRobot(); //Looks for the robot. If it does not exist, we cannot command a robot

            //If the command part of the array is a valid Enum and the robot is valid
            if (Enum.TryParse(instructionParts[0].ToTitleCase(), out RobotGameInstructions command) && robot != null)
            {
                try
                {
                    robot.OnInstruction(instruction); //Tells the robot to act on the instruction string
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

        /// <summary>
        /// This method determines if the position is valid based on the BoardGame's dimensions and the proposed Position
        /// </summary>
        public static bool IsPositionValid(this RobotBoardGame boardGame, Position position)
        {
            Dimensions dimensions = boardGame.GetDimensions();
            return Enumerable.Range(0, dimensions.Width).Contains(position.X) && Enumerable.Range(0, dimensions.Height).Contains(position.Y);
        }

        /// <summary>
        /// This method validates the Turn command based on the following conditions
        /// 1 - It must have at least 2 parts in the instruction array
        /// 2 - The 2nd instruction part must be a valid Direction according to the enum
        /// 3 - The piece must be placed on the grid
        /// </summary>
        public static bool CheckTurnCommandValid(this RobotBoardGame boardGame, Robot robot, string[] instructionParts)
        {
            if (instructionParts.Count() < 2 || !instructionParts[1].ToTitleCase().IsDirectionValid())
            {
                Console.WriteLine("No valid direction was provided! Your choices are North, South, East and West");
            }

            return robot.CheckPieceIsPlaced() 
                && instructionParts.Count() > 1 
                && instructionParts[1].ToTitleCase().IsDirectionValid();
        }

        /// <summary>
        /// This method validates the Place command based on the following conditions
        /// 1 - It must have at least 4 parts in the instruction array
        /// 2 - The piece must not be placed on the grid
        /// 3 - The 2nd and 3rd instruction parts must be a valid co-ordinate
        /// 4 - The 4th instruction part must be a valid Direction according to the enum
        /// 5 - The proposed co-ordinates must be a valid position on the Board
        /// </summary>
        public static bool CheckPlaceCommandValid(this RobotBoardGame boardGame, Robot robot, string[] instructionParts)
        {
            if (robot.CheckPieceIsPlaced())
            {
                Console.WriteLine("The robot is already on the board!");
            }

            if (instructionParts.Count() < 4)
            {
                Console.WriteLine("Input error: Not enough values were provided. This command requires 3 values (X, Y and Direction)");
            }
            else
            {
                if (!instructionParts[1].IsCoordinateValid())
                {
                    Console.WriteLine("Input error: The 2nd value must be a valid number");
                }

                if (!instructionParts[2].IsCoordinateValid())
                {
                    Console.WriteLine("Input error: The 3rd value must be a valid number");
                }

                if (!instructionParts[3].ToTitleCase().IsDirectionValid())
                {
                    Console.WriteLine("Input error: The 4th value must be a valid Direction. Your choices are North, South, East and West");
                }
            }

            return !robot.CheckPieceIsPlaced() && instructionParts.Count() > 3 
                 && instructionParts[3].ToTitleCase().IsDirectionValid()
                 && instructionParts[1].IsCoordinateValid()
                 && instructionParts[2].IsCoordinateValid()
                 && IsPositionValid(boardGame, new Position(instructionParts[2].GetCoordinate(), instructionParts[1].GetCoordinate()));
        }

        /// <summary>
        /// This method validates the Place command based on the following conditions
        /// 1 - The robot must have a valid Direction
        /// 2 - The piece must not be placed on the grid
        /// 3 - The proposed new co-ordinates must be a valid position on the Board
        /// </summary>
        public static bool CheckMoveCommandValid(this RobotBoardGame boardGame, Robot robot, string[] instructionParts)
        {
            var checkPlacementAndDirection = robot.CheckPieceIsPlaced() && robot.GetDirection() != Direction.Unknown;
            if (!checkPlacementAndDirection)
            {
                Console.WriteLine("Error: First instruction must be PLACE");
                return false;
            }

            Position relativePosition = robot.GetMovePosition();
            Position currentPosition = robot.GetPosition();

            bool newPositionCheck = boardGame.IsPositionValid(currentPosition.Add(relativePosition));
            if (!newPositionCheck)
            {
                Console.WriteLine("Stop! Going to fall!");
            }

            return newPositionCheck;
        }

        /// <summary>
        /// This method validates the Place command based on the following conditions
        /// 1 - The piece must not be placed on the grid
        /// </summary>
        public static bool CheckPrintCommandValid(this RobotBoardGame boardGame, Robot robot, string[] instructionParts)
        {
            return robot.CheckPieceIsPlaced();
        }
    }
}
