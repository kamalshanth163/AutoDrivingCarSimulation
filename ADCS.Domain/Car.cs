namespace ADCS.Domain
{
    public class Car
    {
        private readonly Dictionary<string, Action> commandSettings = new();
        private readonly Dictionary<string, Action> positionSettings = new();
        private readonly Dictionary<string, Action<string>> directionSettings = new();

        public Position Position { get; set; }
        public Direction Direction { get; set; }

        public Car() {}

        public Car(Position position, Direction direction) 
        { 
            Position = position;
            Direction = direction;

            Initialize();
        }

        public Car(Car other)
        {
            Position = new Position(other.Position.X, other.Position.Y);
            Direction = new Direction(other.Direction.Face);

            Initialize();
        }

        public Car Drive(string commands)
        {
            foreach (var command in commands)
            {
                commandSettings[command.ToString()].Invoke();
            }
            return this;
        }

        public string GetCurrentPosition()
        {
            return $"{Position.X} {Position.Y} {Direction.Face}";
        }

        private void Initialize()
        {
            commandSettings.Add("F", () => MoveForward());
            commandSettings.Add("L", () => Turn("L"));
            commandSettings.Add("R", () => Turn("R"));

            positionSettings.Add("N", () => { if (Position.Y+1 <= Field.MaxY) Position.Y++; });
            positionSettings.Add("S", () => { if (Position.Y-1 >= 0) Position.Y--; });
            positionSettings.Add("E", () => { if (Position.X+1 <= Field.MaxX) Position.X++; });
            positionSettings.Add("W", () => { if (Position.X-1 >= 0) Position.X--; });

            directionSettings.Add("N", (side) => { Direction.Face = side == "L" ? "W" : "E"; });
            directionSettings.Add("S", (side) => { Direction.Face = side == "L" ? "E" : "W"; });
            directionSettings.Add("E", (side) => { Direction.Face = side == "L" ? "N" : "S"; });
            directionSettings.Add("W", (side) => { Direction.Face = side == "L" ? "S" : "N"; });
        }

        private void MoveForward()
        {
            positionSettings[Direction.Face].Invoke();
        }

        private void Turn(string side)
        {
            directionSettings[Direction.Face].Invoke(side);
        }
    }
}
