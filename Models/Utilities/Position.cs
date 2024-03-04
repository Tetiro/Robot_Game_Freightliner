namespace Robot_Game_Freightliner.Models.Utils
{
    /// <summary>
    /// This class contains the properties for Dimensions
    /// </summary>
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x; 
            Y = y;
        }
    }

    /// <summary>
    /// This class contains the extension methods related to Position
    /// </summary>
    public static class PositionExtensions
    {
        /// <summary>
        /// This method validates if a string is a valid integer
        /// </summary>
        public static bool IsCoordinateValid(this string valueString)
        {
            return int.TryParse(valueString, out int value);
        }

        /// <summary>
        /// This method returns an integer based on a string parameter
        /// </summary>
        public static int GetCoordinate(this string valueString)
        {
            int.TryParse(valueString, out int value);
            return value;
        }

        /// <summary>
        /// This method returns the relative Position parameter added to the original Parameter value
        /// </summary>
        public static Position Add(this Position originalPosition, Position relativePosition)
        {
            return new Position(originalPosition.X + relativePosition.X, originalPosition.Y + relativePosition.Y);
        }
    }
}
