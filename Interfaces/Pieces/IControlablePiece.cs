using Robot_Game_Freightliner.Models.Pieces;

namespace Robot_Game_Freightliner.Interfaces.Pieces
{
    public interface IControlablePiece
    {
        void ProcessInstruction(string instruction);
    }
}
