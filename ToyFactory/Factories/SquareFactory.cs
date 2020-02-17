using System;
using System.Collections.Generic;
using System.Text;

namespace ToyFactory.Factories
{
    public class SquareFactory : ShapeFactory
    {
        

        public override Shape Create(string color)
        {
            return new Square(color);
        }
    }
}
