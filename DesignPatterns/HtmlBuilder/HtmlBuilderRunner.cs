using System;
using System.Collections.Generic;
using System.Text;

namespace Builders.HtmlBuilder
{
    public static class HtmlBuilderRunner
    {
        public static void Run()
        {
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello")
                .AddChild("li", "world");
            Console.WriteLine(builder.ToString());
        }
    }
}
