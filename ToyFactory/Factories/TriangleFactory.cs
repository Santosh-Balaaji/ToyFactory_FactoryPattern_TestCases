using System;
using System.Collections.Generic;
using System.Text;

namespace ToyFactory.Factories
{
    public class TriangleFactory : ShapeFactory
    {
        public override Shape Create(string color)
        {
            return new Triangle(color);
        }
    }
}
