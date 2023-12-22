using ADCS.Domain;

namespace ADCS.Application
{
    public class DriveService : IDriveService
    {
        public Car DriveCar(string commands, Car carStart)
        {
            return carStart.Drive(commands);
        }
    }
}
