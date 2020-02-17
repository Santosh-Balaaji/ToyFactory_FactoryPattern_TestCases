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
        public static decimal SurgePrice = 1;



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
                surgePrice = shape.ShapeCount*SurgePrice ;

            return surgePrice;
        }

        public static decimal? CalculateSurgePriceForEachShape(List<Shape> shapeList, string shapeName)
        { 
            decimal? surgePrice = 0;
            foreach (var shape in shapeList)
            {
                if (shape.Color == "Red" && shape.ShapeName == shapeName)
                    surgePrice += shape.ShapeCount* SurgePrice;
            }
            return surgePrice;
        }
        public static int? GetTotalNoOfItemsPerShape(List<Shape> shapeList, string shapeName)
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
        public static int? GetTotalNoOfItemsPerShapeandColor(List<Shape> shapeList, string shapeName, string color)
        {
            int? count = 0;
            foreach (var shape in shapeList)
            {
                if (shape.Color == color && shape.ShapeName == shapeName)
                    count = shape.ShapeCount;
            }
            return count;
        }

        public static decimal GetTotalCostPerShape(List<Shape> shapeList, string shapeName)
        {
            decimal cost = 0;
            foreach (var shape in shapeList)
            {
                if (shape.ShapeName == shapeName)
                    cost += shape.Cost;
            }
            return cost;
        }

    }
}
