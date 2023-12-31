﻿using ADCS.Domain;

namespace ADCS.Application
{
    public class SimulatorRepository : ISimulatorRepository
    {
        public void SetField(string fieldInput)
        {
            var values = fieldInput.Trim().Split(" ");
            var width = int.Parse(values[0]);
            var height = int.Parse(values[1]);

            Field.Width = width;
            Field.Height = height;
            Field.MaxX = width - 1;
            Field.MaxY = height - 1;
        }

        public void CreatePositionAndDirection(string positionInput, out Position position, out Direction direction)
        {
            var values = positionInput.Trim().Split(" ");

            var x = int.Parse(values[0]);
            var y = int.Parse(values[1]);
            var directionFace = values[2];

            position = new Position(x, y);
            direction = new Direction(directionFace);
        }

        public Car CreateCar(Position position, Direction direction)
        {
            var car = new Car(position, direction);
            return car;
        }

        public Car DriveCar(string commands)
        {
            throw new NotImplementedException();
        }
    }
}
