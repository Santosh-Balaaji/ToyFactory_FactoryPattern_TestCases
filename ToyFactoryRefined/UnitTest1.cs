using NUnit.Framework;
using System;
using System.Collections.Generic;
using ToyFactory;
using ToyFactory.Factories;

namespace ToyFactoryRefined
{
    [TestFixture]
    public class Tests
    {
        List<Shape> shapeList;
        Dictionary<string, decimal> shapeCostDict;
        public Dictionary<string, ShapeFactory> factories;

        [SetUp]
        public void Setup()
        {
            factories = new Dictionary<string, ShapeFactory>();
            factories.Add("Square", new SquareFactory());
            factories.Add("Circle", new CircleFactory());
            factories.Add("Triangle", new TriangleFactory());
            shapeList = ConcreteShapeFactory.GenerateShapeList(factories);
            shapeCostDict = new Dictionary<string, decimal>();
                        
        }
        public Shape GetObject(string shapeName, string color)
        {
            Shape shapeObject = new Shape();
            foreach (var shape in shapeList)
            {
                if (shape.ShapeName == shapeName && shape.Color == color)
                    shapeObject = shape;
            }
            return shapeObject;
        
        }

        [Test]
        public void CalculateTotal_EmptyList_Return0()
        {
            
            var total = Shape.CalculateTotal(shapeList);
            Assert.AreEqual(total,0);
        }
        [Test]
        public void CalculateTotal_SingleRedSquare_Return2()
        {
            Shape shapeObject = GetObject("Square", "Red");
            shapeObject.ShapeCount = 1;
            var total = Shape.CalculateTotal(shapeList);
            Assert.AreEqual(total, 2);
        }

        [Test]
        public void CalculateTotal_RedandBlueSquares_Return3()
        {
            Shape redSquare = GetObject("Square", "Red");
            Shape blueSquare = GetObject("Square", "Blue");
            redSquare.ShapeCount = 1;
            blueSquare.ShapeCount = 1;
            var total = Shape.CalculateTotal(shapeList);
            Assert.AreEqual(total, 3);
        }

        [Test]
        public void CalculateTotal_RedBlueSquaresandRedTriangle_Return6()
        {
            Shape redSquare = GetObject("Square", "Red");
            Shape blueSquare = GetObject("Square", "Blue");
            Shape redTriangle = GetObject("Triangle","Red");
            redSquare.ShapeCount = 1;
            blueSquare.ShapeCount = 1;
            redTriangle.ShapeCount = 1;
            var total = Shape.CalculateTotal(shapeList);
            Assert.AreEqual(total, 6);
        }

        [Test]
        public void CalculateTotal_RedBlueSquaresRedTriangleandTwoRedCircle_Return14()
        {
            Shape redSquare = GetObject("Square", "Red");
            Shape blueSquare = GetObject("Square", "Blue");
            Shape redTriangle = GetObject("Triangle", "Red");
            Shape redCircle = GetObject("Circle", "Red");
            redSquare.ShapeCount = 1;
            blueSquare.ShapeCount = 1;
            redTriangle.ShapeCount = 1;
            redCircle.ShapeCount = 2;
            var total = Shape.CalculateTotal(shapeList);
            Assert.AreEqual(total, 14);
        }



    }
}