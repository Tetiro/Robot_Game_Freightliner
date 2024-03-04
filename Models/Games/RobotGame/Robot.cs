using Robot_Game_Freightliner.Interfaces.Pieces;
using Robot_Game_Freightliner.Models.Pieces;
using Robot_Game_Freightliner.Models.Utils;
using Robot_Game_Freightliner.Utilities;

namespace Robot_Game_Freightliner.Models.Games.RobotGame
{
    /// <summary>
    /// This class contains the properties and methods for the behaviour of a Robot
    /// </summary>
    public class Robot : ControlablePiece, IControlablePiece
    {
        private Direction _direction = Direction.Unknown;

        /// <summary>
        /// This method handles the behaviour of the robot based on the instruction string
        /// </summary>
        public override void OnInstruction(string instruction)
        {
            string[] instructionParts = instruction.Split(' ');

            if (Enum.TryParse(instructionParts[0].ToTitleCase(), out RobotGameInstructions command)) //If the 1st part of the string is a valid Enum command
            {
                try
                {
                    switch (command) //Based on the command that has been provided
                    {
                        case RobotGameInstructions.Place: //Sets the position of the piece on the board and its direction
                            {
                                Position position = new Position(instructionParts[2].GetCoordinate(), instructionParts[1].GetCoordinate());
                                PlacePieceOnGrid(position.X, position.Y);
                                SetDirection(instructionParts[3].ToTitleCase().GetDirection());
                            }; break;
                        case RobotGameInstructions.Turn: //Sets the direction of the piece
                            {
                                SetDirection(instructionParts[1].ToTitleCase().GetDirection());
                            }; break;
                        case RobotGameInstructions.Move: //Moves the piece based on the new Position
                            {
                                MoveRelativeToPosition(GetMovePosition());
                            }; break;
                        case RobotGameInstructions.Print: //Outputs the position and direction of the Robot
                            {
                                Console.WriteLine($"{GetPosition().Y} {GetPosition().X} {GetDirection().ToString().ToUpper()}");
                            }; break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error in {nameof(OnInstruction)}: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid instruction");
            }
        }

        /// <summary>
        /// This method returns the Direction enum value
        /// </summary>
        public Direction GetDirection()
        {
            return _direction;
        }

        /// <summary>
        /// This method sets the Direction based on the Direction Enum parameter
        /// </summary>
        public void SetDirection(Direction direction)
        {
            _direction = direction;
        }

        /// <summary>
        /// This method overrides the BoardPiece's GetPieceCharacter to return R
        /// </summary>
        public override char GetPieceCharacter()
        {
            return 'R';
        }

        /// <summary>
        /// This method returns the new position based on the the Direction and current Position
        /// </summary>
        public Position GetMovePosition()
        {
            Position position = GetPosition();

            switch (GetDirection())
            {
                case Direction.East: return new Position(1, 0);
                case Direction.West: return new Position(-1, 0);
                case Direction.North: return new Position(0, 1);
                case Direction.South: return new Position(0, -1);
                default: return new Position(0, 0);
            }
        }
    }
}
