using System;
using System.Collections.Generic;
using System.Text;

namespace ToyFactory
{
    public class Shape
    {
        public string ShapeName { get; set; }
        public string Color { get; set; }
        public int? ShapeCount { get; set; }
        public decimal Cost { get; set; }

       
       
        public static decimal? CalculateTotal(List<Shape> shapeList)
        {
            decimal? total = 0;

            foreach (var shape in shapeList)
            {
                if (shape.ShapeCount.HasValue)
                    total += (shape.ShapeCount * shape.Cost) + Shape.CalculateSurgePriceForRedShapes(shape);
                else
                    total += 0;
            }
            return total;
        }

        public static decimal? CalculateSurgePriceForRedShapes(Shape shape)
        {
            decimal? surgePrice = 0;
            if (shape.Color == "Red")
                surgePrice = shape.ShapeCount;

            return surgePrice;
        }
        public static int? GetTotalCostOfEachShape(List<Shape> shapeList, string shapeName)
        {
            int? count = 0;
            foreach (var shape in shapeList)
            {
                if(shape.ShapeName == shapeName)
                    count += shape.ShapeCount;
            }
            return count;
        }

        public static int? GetTotalNoOfItemsPerColor(List<Shape> shapeList, string color)
        {
            int? count = 0;
            foreach (var shape in shapeList)
            {
                if (shape.Color == color)
                    count += shape.ShapeCount;
            }
            return count;
        }
    }
}
