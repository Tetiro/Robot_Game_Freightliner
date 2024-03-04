namespace Robot_Game_Freightliner.Models.Utils
{
    /// <summary>
    /// This class contains the properties for Dimensions
    /// </summary>
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
}
