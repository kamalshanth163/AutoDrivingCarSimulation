namespace ADCS.Domain
{
    public class Field
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public Field(int width, int height)
        {
            Width = width;
            Height = height;
            MaxX = width - 1;
            MaxY = height - 1;
        }

    }
}
