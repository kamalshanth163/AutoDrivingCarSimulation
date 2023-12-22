namespace ADCS.Domain
{
    public class Simulation
    {
        public FieldDto Field { get; set; }
        public Car CarStart { get; set; }
        public Car CarEnd { get; set; }

        public Simulation(FieldDto field, Car carStart, Car carEnd)
        {
            Field = field;
            CarStart = carStart;
            CarEnd = carEnd;
        }

    }
}
