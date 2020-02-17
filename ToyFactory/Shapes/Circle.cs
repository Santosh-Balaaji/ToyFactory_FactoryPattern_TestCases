using System;
using System.Collections.Generic;
using System.Text;

namespace ToyFactory
{
    public class Circle: Shape
    {
        public Circle(string color)
        {
            ShapeName = "Circle";
            Color = color;
            Cost = 3;
        }

    }
}
