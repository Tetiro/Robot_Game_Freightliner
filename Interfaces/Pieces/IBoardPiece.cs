using Robot_Game_Freightliner.Models.Pieces;
using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Interfaces.Pieces
{
    /// <summary>
    /// This interface determines the required methods for IBoardPiece based classes
    /// </summary>
    public interface IBoardPiece
    {
        void PlacePieceOnGrid(int x, int y);
        void PlacePieceOnGrid(Position position);
        void SetPosition(int x, int y);
        void SetPosition(Position position);
        Position GetPosition();
        bool CheckPieceIsPlaced();
        char GetPieceCharacter();
    }
}
