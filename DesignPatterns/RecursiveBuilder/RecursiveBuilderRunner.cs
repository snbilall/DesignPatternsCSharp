using System;
using System.Collections.Generic;
using System.Text;

namespace Builders.RecursiveBuilder
{
    public static class RecursiveBuilderRunner
    {
        public static void Run()
        {
            var builderApi = new PersonBuilderApi();
            var person = builderApi.Called("Bilal").WorksAsA("comp eng").Build();
            Console.WriteLine(person);
        }
    }
}
