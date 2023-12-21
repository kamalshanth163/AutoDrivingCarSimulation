namespace ADCS.Domain
{
    public sealed class Car
    {
        private static Car instance = null;
        private static readonly object lockObject = new object();

        private Car() { }

        public static Car Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new Car();
                    }
                }

                return instance;
            }
        }

        public Position Position { get; set; }
        public Direction Direction { get; set; }
    }
}
