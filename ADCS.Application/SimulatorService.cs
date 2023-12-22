using ADCS.Domain;

namespace ADCS.Application
{
    public class SimulatorService : ISimulatorService
    {
        private readonly ISimulatorRepository _repository;
        private readonly IDriveService _driveService;

        public SimulatorService(ISimulatorRepository repository, IDriveService driveService)
        {
            _repository = repository;
            _driveService = driveService;
        }
        public Simulation Execute(Instruction instruction)
        {
            var field = _repository.CreateField(instruction.FieldInput);

            _repository.CreatePositionAndDirection(instruction.PositionInput, out Position position, out Direction direction);

            var carStart = _repository.CreateCar(position, direction);

            var carState = _driveService.DriveCar(instruction.Commands, field, new Car(carStart));

            var carEnd = carState.Car;

            return new Simulation(field, carStart, carEnd, carState.State);
        }
    }
}
