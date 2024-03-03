using Robot_Game_Freightliner.Interfaces.Pieces;

namespace Robot_Game_Freightliner.Models.Pieces
{
    public class ControlablePiece : MoveablePiece, IControlablePiece
    {
        public virtual void ProcessInstruction(string instruction)
        {
            
        }
    }
}
