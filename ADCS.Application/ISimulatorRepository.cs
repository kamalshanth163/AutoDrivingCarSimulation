using ADCS.Domain;

namespace ADCS.Application
{
    public interface ISimulatorRepository
    {
        Field CreateField(string fieldInput);

        void CreatePositionAndDirection(string positionInput, out Position position, out Direction direction);

        Car CreateCar(Position position, Direction direction);

    }
}
