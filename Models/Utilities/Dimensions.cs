namespace Robot_Game_Freightliner.Models.Utils
{
    public class Dimensions
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Dimensions(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }

    public static class DimensionExtensions
    {
        public static bool IsDirectionValid(this string valueString)
        {
            return Enum.TryParse(valueString, out Direction value);
        }

        public static Direction GetDirection(this string valueString)
        {
            Enum.TryParse(valueString, out Direction value);
            return value;
        }
    }
}
