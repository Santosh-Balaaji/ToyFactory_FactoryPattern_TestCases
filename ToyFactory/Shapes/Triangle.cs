using System;
using System.Collections.Generic;
using System.Text;

namespace ToyFactory
{
    public class Triangle: Shape
    {
        public Triangle(string color)
        {
            ShapeName = "Triangle";
            Color = color;
            Cost = 2;
        }
    }
}
