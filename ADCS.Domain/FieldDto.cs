namespace ADCS.Domain
{
    public class FieldDto
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public FieldDto()
        {
            Width = Field.Width;
            Height = Field.Height;
            MaxX = Field.MaxX;
            MaxY = Field.MaxY;
        }
    }
}
