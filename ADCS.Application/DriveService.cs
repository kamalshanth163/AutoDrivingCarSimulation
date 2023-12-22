using ADCS.Domain;

namespace ADCS.Application
{
    public class DriveService : IDriveService
    {
        public Car DriveCar(string commands, Field field, Car carStart)
        {
            var carEnd = carStart.Drive(commands);

            return carEnd;
        }
    }
}
