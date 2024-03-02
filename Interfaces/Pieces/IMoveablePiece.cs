using Robot_Game_Freightliner.Models.Pieces;

namespace Robot_Game_Freightliner.Interfaces.Pieces
{
    public interface IMoveablePiece
    {
        void MoveRelativeToPosition(int x, int y);
        void MoveRelativeToPosition(Position position);
    }
}
