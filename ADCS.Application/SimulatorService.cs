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
        public async Task<Simulation> Execute(Instruction instruction)
        {
            _repository.SetField(instruction.FieldInput);

            _repository.CreatePositionAndDirection(instruction.PositionInput, out Position position, out Direction direction);

            var carStart = _repository.CreateCar(position, direction);

            var carEnd = _driveService.DriveCar(instruction.Commands, new Car(carStart));

            var fieldDto = new FieldDto();

            return new Simulation(fieldDto, carStart, carEnd);
        }
    }
}
