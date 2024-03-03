using Robot_Game_Freightliner.Models.Pieces;
using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Interfaces.Pieces
{
    public interface IMoveablePiece
    {
        void MoveRelativeToPosition(int x, int y);
        void MoveRelativeToPosition(Position position);
    }
}
