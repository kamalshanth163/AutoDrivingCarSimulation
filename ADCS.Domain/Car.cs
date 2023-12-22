namespace ADCS.Domain
{
    public class Car
    {
        private readonly Dictionary<string, Action> commandSettings = new();
        private readonly Dictionary<string, Action> positionSettings = new();
        private readonly Dictionary<string, Action<string>> directionSettings = new();

        public Position Position { get; set; }
        public Direction Direction { get; set; }

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

        public CarState Drive(string commands, Field field)
        {
            var carState = new CarState(this);

            foreach (var command in commands)
            {
                commandSettings[command.ToString()].Invoke();
                if (!IsCarWithinField(Position, field))
                {
                    carState.State = "Failure";
                    return carState;
                }
            }

            return carState;
        }

        private bool IsCarWithinField(Position position, Field field)
        {
            return (position.X <= field.MaxX && position.X >= 0) && (position.Y <= field.MaxY && position.Y >= 0);
        }

        private void Initialize()
        {
            commandSettings.Add("F", () => MoveForward());
            commandSettings.Add("L", () => Turn("L"));
            commandSettings.Add("R", () => Turn("R"));

            positionSettings.Add("N", () => { Position.Y++; });
            positionSettings.Add("S", () => { Position.Y--; });
            positionSettings.Add("E", () => { Position.X++; });
            positionSettings.Add("W", () => { Position.X--; });

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
