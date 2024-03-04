using Robot_Game_Freightliner.Interfaces.Pieces;

namespace Robot_Game_Freightliner.Models.Pieces
{
    /// <summary>
    /// This class contains the properties and methods for the behaviour of a Controlable Piece
    /// It is to be inherited by other classes
    /// </summary>
    public class ControlablePiece : MoveablePiece, IControlablePiece
    {
        /// <summary>
        /// This method is a virtual method to be overriden with a child class' behaviour
        /// </summary>
        public virtual void OnInstruction(string instruction)
        {
            
        }
    }
}
