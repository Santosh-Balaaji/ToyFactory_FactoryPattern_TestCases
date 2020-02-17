using System;
using System.Collections.Generic;
using System.Text;

namespace ToyFactory.Factories
{
    public class CircleFactory : ShapeFactory
    {
        public override Shape Create(string color)
        {
            return new Circle(color);
        }
    }
}
