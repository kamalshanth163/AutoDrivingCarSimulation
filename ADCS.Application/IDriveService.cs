using ADCS.Domain;

namespace ADCS.Application
{
    public interface IDriveService
    {
        CarState DriveCar(string commands, Field field, Car carStart);
    }
}
