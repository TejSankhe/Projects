using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runtimeObject
{
    class Rectangle : Shape
    {
        public override void draw(int y)
        {
            Console.WriteLine("Rectangle");
        }
    }
}
