using System.Globalization;

namespace Robot_Game_Freightliner.Utilities
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string originalValue)
        {
            TextInfo textInfo = new CultureInfo("en-GB", false).TextInfo;
            return textInfo.ToTitleCase(originalValue.ToLower());
        }
    }
}
