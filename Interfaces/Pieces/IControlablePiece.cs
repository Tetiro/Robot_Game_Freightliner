using Robot_Game_Freightliner.Models.Pieces;

namespace Robot_Game_Freightliner.Interfaces.Pieces
{
    /// <summary>
    /// This interface determines the required methods for IControlablePiece based classes
    /// </summary>
    public interface IControlablePiece
    {
        void OnInstruction(string instruction);
    }
}
