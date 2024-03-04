using System.Globalization;

namespace Robot_Game_Freightliner.Utilities
{
    /// <summary>
    /// This class handles all the extension methods required for string variables
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// This method returns a string to TitleCase for one worded strings
        /// </summary>
        public static string ToTitleCase(this string originalValue)
        {
            TextInfo textInfo = new CultureInfo("en-GB", false).TextInfo;
            return textInfo.ToTitleCase(originalValue.ToLower());
        }
    }
}
