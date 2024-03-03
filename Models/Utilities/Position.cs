namespace Robot_Game_Freightliner.Models.Utils
{
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

    public static class PositionExtensions
    {
        public static bool IsCoordinateValid(this string valueString)
        {
            return int.TryParse(valueString, out int value);
        }

        public static int GetCoordinate(this string valueString)
        {
            int.TryParse(valueString, out int value);
            return value;
        }
    }
}
