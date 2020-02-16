using System;
using System.Collections.Generic;
using System.Text;

namespace ToyFactoryRefined
{
    public class Shape
    {
        public string ShapeName { get; set; }
        public string Color { get; set; }
        public int ShapeCount { get; set; }
        public decimal Cost { get; set; }

        public Shape()
        { 
        }
        public Shape(string shapeName, string color, decimal shapeCost)
        {
            ShapeName = shapeName;
            Color = color;
            Cost = shapeCost;
        }
        public static decimal CalculateTotal(Shape shape) {
            var total= (shape.Cost * shape.Cost)+ Shape.CalculateSurgePriceForRedShapes(shape);
            return total;
        }

        public static decimal CalculateSurgePriceForRedShapes(Shape shape)
        {
            decimal surgePrice = 0; 
            if (shape.Color == "Red")
                surgePrice++;

            return surgePrice;
        }
    }
}
