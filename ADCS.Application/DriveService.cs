using ADCS.Domain;

namespace ADCS.Application
{
    public class DriveService : IDriveService
    {
        public CarState DriveCar(string commands, Field field, Car carStart)
        {
            return carStart.Drive(commands, field);
        }
    }
}
