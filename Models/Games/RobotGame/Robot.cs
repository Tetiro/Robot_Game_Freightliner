using Robot_Game_Freightliner.Interfaces.Pieces;
using Robot_Game_Freightliner.Models.Pieces;
using Robot_Game_Freightliner.Models.Utils;
using Robot_Game_Freightliner.Utilities;

namespace Robot_Game_Freightliner.Models.Games.RobotGame
{
    public class Robot : ControlablePiece, IControlablePiece
    {
        private Direction _direction = Direction.Unknown;

        public override void OnInstruction(string instruction)
        {

            string[] instructionParts = instruction.Split(' ');

            if (Enum.TryParse(instructionParts[0].ToCamelCase(), out RobotGameInstructions command))
            {
                try
                {
                    switch (command)
                    {
                        case RobotGameInstructions.Place:
                            {
                                Position position = new Position(instructionParts[2].GetCoordinate(), instructionParts[1].GetCoordinate());
                                PlacePieceOnGrid(position.X, position.Y);
                                SetDirection(instructionParts[3].ToCamelCase().GetDirection());
                            }; break;
                        case RobotGameInstructions.Turn:
                            {
                                SetDirection(instructionParts[1].ToCamelCase().GetDirection());
                            }; break;
                        case RobotGameInstructions.Move:
                            {
                                Position position = GetNewPosition();
                                SetPosition(position.X, position.Y);
                            }; break;
                        case RobotGameInstructions.Print:
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

        public Direction GetDirection()
        {
            return _direction;
        }

        public void SetDirection(Direction direction)
        {
            _direction = direction;
        }

        public override char GetPieceCharacter()
        {
            return 'R';
        }

        public Position GetNewPosition()
        {
            Position position = GetPosition();

            switch (GetDirection())
            {
                case Direction.East: return new Position(position.X + 1, position.Y);
                case Direction.West: return new Position(position.X - 1, position.Y);
                case Direction.North: return new Position(position.X, position.Y + 1);
                case Direction.South: return new Position(position.X, position.Y - 1);
                default: return new Position(position.X, position.Y);
            }
        }
    }
}
