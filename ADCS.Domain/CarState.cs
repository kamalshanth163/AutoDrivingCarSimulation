namespace ADCS.Domain
{
    public class CarState
    {
        public Car Car { get; set; }
        public string State { get; set; } = "Success";

        public CarState(Car car)
        {
            Car = car;
        }
    }
}
