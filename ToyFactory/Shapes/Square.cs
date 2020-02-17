using System;
using System.Collections.Generic;
using System.Text;

namespace ToyFactory
{
    public class Square: Shape
    {
        public Square(string color)
        {
            ShapeName = "Square";
            Color = color;
            Cost = 1;
        }
    }
}
