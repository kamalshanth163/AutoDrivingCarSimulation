namespace ADCS.Domain
{
    public class Car
    {
        public Position Position { get; set; }
        public Direction Direction { get; set; }

        public Car(Position position, Direction direction) 
        { 
            Position = position;
            Direction = direction;
        }

    }
}
