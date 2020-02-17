using System;
using System.Collections.Generic;
using System.Text;

namespace ToyFactory.Factories
{
    public  abstract class ShapeFactory
    {
        public  abstract Shape Create(string color);
    }
}
