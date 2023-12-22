namespace ADCS.Domain
{
    public class Simulation
    {
        public Field Field { get; set; }
        public Car CarStart { get; set; }
        public Car CarEnd { get; set; }
        public Simulation(Field field, Car carStart, Car carEnd)
        {
            Field = field;
            CarStart = carStart;
            CarEnd = carEnd;
        }

    }
}
