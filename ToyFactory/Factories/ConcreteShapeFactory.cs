using System;
using System.Collections.Generic;
using System.Text;
using ToyFactory.Factories;

namespace ToyFactory
{
    public class ConcreteShapeFactory
    {
        public static List<Shape> GenerateShapeList(Dictionary<string, ShapeFactory> factories)
        {
            List<Shape> shapeList = new List<Shape>();
            foreach (var shape in Enum.GetNames(typeof(EnumerationValues.Shapes)))
            {
                foreach (var color in Enum.GetNames(typeof(EnumerationValues.Color)))
                {
                    var shapeObject = GenerateObject(shape,color,factories);
                    shapeList.Add(shapeObject);
                }
            }
            return shapeList;
            
        }

        public static Shape GenerateObject(string shapeName, string color, Dictionary<string, ShapeFactory> factories)
        {
            var factoryClass = factories[shapeName];
            Shape shape = factoryClass.Create(color);
            return shape;
        }
    }
}
