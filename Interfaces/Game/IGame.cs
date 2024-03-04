using Robot_Game_Freightliner.Models.Pieces;
using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Interfaces.Games
{
    /// <summary>
    /// This interface determines the required methods for IGame based classes
    /// </summary>
    public interface IGame
    {
        void SetupBoard(int width, int height, IEnumerable<BoardPiece> boardPieces = null);
        void SetupBoard(Dimensions dimensions, IEnumerable<BoardPiece> boardPieces = null);
        void OnInstruction(string instruction);
        void DisplayGame();
        Dimensions GetDimensions();
        IEnumerable<BoardPiece> GetPieces();
    }
}
