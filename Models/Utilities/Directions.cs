namespace Robot_Game_Freightliner.Models.Utils
{
    /// <summary>
    /// This file holds the enum for Directions
    /// </summary>
    public enum Direction
    {
        North,
        South,
        East,
        West,
        Unknown
    }

    /// <summary>
    /// This class contains the extension methods related to Directions
    /// </summary>
    public static class DirectionExtensions
    {
        /// <summary>
        /// This method validates a string to determine if it is a valid Direction enum
        /// </summary>
        public static bool IsDirectionValid(this string valueString)
        {
            return Enum.TryParse(valueString, out Direction value);
        }

        /// <summary>
        /// This method returns a Direction enum based on a string parameter
        /// </summary>
        public static Direction GetDirection(this string valueString)
        {
            Enum.TryParse(valueString, out Direction value);
            return value;
        }
    }
}
