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

        public CarState Drive(string commands)
        {
            string state = null;

            foreach (var command in commands)
            {
                commandSettings[command.ToString()].Invoke();
            }

            var carState = new CarState(this, state);
            return carState;
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
