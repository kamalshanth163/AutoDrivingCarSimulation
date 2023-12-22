namespace ADCS.Domain
{
    public class Direction
    {
        public string Face { get; set; }

        public Direction() { }

        public Direction(string face)
        {
            Face = face;
        }
    }
}
