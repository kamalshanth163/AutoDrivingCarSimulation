namespace ADCS.Domain
{
    public class CarState
    {
        public Car Car { get; set; }
        public string State { get; set; }

        public CarState(Car car, string state)
        {
            Car = car;
            State = state;
        }
    }
}
