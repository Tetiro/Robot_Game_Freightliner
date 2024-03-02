using Robot_Game_Freightliner.Models.Pieces;
using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Interfaces.Pieces
{
    public interface IBoardPiece
    {
        void PlacePieceOnGrid(int x, int y);
        void PlacePieceOnGrid(Position position);
        void SetPosition(int x, int y);
        void SetPosition(Position position);
        Position GetPosition();
        bool CheckPieceIsPlaced();
    }
}
