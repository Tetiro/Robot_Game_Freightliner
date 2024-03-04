using Robot_Game_Freightliner.Models.Grids;
using Robot_Game_Freightliner.Models.Pieces;
using Robot_Game_Freightliner.Models.Utils;

namespace Robot_Game_Freightliner.Interfaces.Grids
{
    /// <summary>
    /// This interface determines the required methods for IGrid based classes
    /// </summary>
    public interface IGrid
    {
        void SetupGrid(int width, int height, IEnumerable<BoardPiece> boardPieces = null);
        void SetupGrid(Dimensions dimensions, IEnumerable<BoardPiece> boardPieces = null);
        void ClearGrid();
        void PrintGrid();
        Dimensions GetDimensions();
        IEnumerable<BoardPiece> GetPieces();
    }
}
