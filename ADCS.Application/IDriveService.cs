using ADCS.Domain;

namespace ADCS.Application
{
    public interface IDriveService
    {
        Car DriveCar(string commands, Field field, Car carStart);
    }
}
