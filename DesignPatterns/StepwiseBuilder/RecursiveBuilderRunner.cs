using System;
using System.Collections.Generic;
using System.Text;

namespace Builders.StepwiseBuilder
{
    public static class StepwiseBuilderRunner
    {
        public static void Run()
        {
            var builder = CarBuilder.Create()
                .OfType(CarType.CrossOver)
                .WithWheels(18)
                .Build();
            Console.WriteLine(builder);
        }
    }
}
