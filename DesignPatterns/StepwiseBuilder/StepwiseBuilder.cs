using System;
using System.Collections.Generic;
using System.Text;

namespace Builders.StepwiseBuilder
{
    public enum CarType
    {
        Sedan,
        CrossOver
    }
    public class Car
    {
        public CarType Type { get; set; }
        public int WheelSize { get; set; }

        public override string ToString()
        {
            return $"Type: {Type.ToString()} WheelSize: {WheelSize}";
        }
    }

    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }

    public interface ISpecifyWheelSize
    {
        IBuildCar WithWheels(int size);
    }

    public interface IBuildCar
    {
        public Car Build();
    }

    public static class CarBuilder
    {
        private class Impl : ISpecifyWheelSize, ISpecifyCarType, IBuildCar
        {
            private Car car = new Car();
            public Car Build()
            {
                return car;
            }

            public ISpecifyWheelSize OfType(CarType type)
            {
                car.Type = type;
                return this;
            }

            public IBuildCar WithWheels(int size)
            {
                switch (car.Type)
                {
                    case CarType.CrossOver when size < 17 || size > 20:
                    case CarType.Sedan when size < 15 || size > 27:
                        throw new ArgumentException("wrong wheel size by car type");
                }
                return this;
            }
        }

        public static ISpecifyCarType Create()
        {
            return new Impl();
        }
    }
}
