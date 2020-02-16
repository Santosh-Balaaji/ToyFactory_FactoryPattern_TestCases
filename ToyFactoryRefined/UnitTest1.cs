using NUnit.Framework;
using System;
using System.Collections.Generic;
using ToyFactory;

namespace ToyFactoryRefined
{
    [TestFixture]
    public class Tests
    {
        Shape redSquare;
        Shape blueSquare;
        Shape redTriangle;
        Shape redCircle;
        Dictionary<string, decimal> shapeCostDict; 
        List<Shape> shapeList; 
        [SetUp]
        public void Setup()
        {
            redSquare = new Shape("Square","Red");
            blueSquare = new Shape("Square", "Blue");
            redTriangle = new Shape("Triangle","Red");
            redCircle = new Shape("Circle", "Red");
            shapeList = new List<Shape>();
            shapeCostDict = new Dictionary<string, decimal>();
            shapeCostDict.Add("Square", 1);
            shapeCostDict.Add("Triangle", 2);
            shapeCostDict.Add("Circle", 3);
            
        }

        [Test]
        public void CalculateTotal_EmptyList_Return0()
        {
            var total = Shape.CalculateTotal(shapeList,shapeCostDict);
            Assert.AreEqual(total,0);
        }
        [Test]
        public void CalculateTotal_SingleRedSquare_Return2()
        {
            shapeList.Add(redSquare);
            redSquare.ShapeCount = 1;
            var total = Shape.CalculateTotal(shapeList,shapeCostDict);
            Assert.AreEqual(total, 2);
        }

        [Test]
        public void CalculateTotal_RedandBlueSquares_Return3()
        {
            shapeList.Add(redSquare);
            shapeList.Add(blueSquare);
            redSquare.ShapeCount = 1;
            blueSquare.ShapeCount = 1;
            var total = Shape.CalculateTotal(shapeList,shapeCostDict);
            Assert.AreEqual(total, 3);
        }

        [Test]
        public void CalculateTotal_RedBlueSquaresandRedTriangle_Return6()
        {
            shapeList.Add(redSquare);
            shapeList.Add(blueSquare);
            shapeList.Add(redTriangle);
            redTriangle.ShapeCount = 1;
            redSquare.ShapeCount = 1;
            blueSquare.ShapeCount = 1;
            var total = Shape.CalculateTotal(shapeList,shapeCostDict);
            Assert.AreEqual(total, 6);
        }

        [Test]
        public void CalculateTotal_RedBlueSquaresRedTriangleandRedCircle_Return14()
        {
            shapeList.Add(redSquare);
            shapeList.Add(blueSquare);
            shapeList.Add(redTriangle);
            shapeList.Add(redCircle);
            redTriangle.ShapeCount = 1;
            redSquare.ShapeCount = 1;
            blueSquare.ShapeCount = 1;
            redCircle.ShapeCount = 2;
            var total = Shape.CalculateTotal(shapeList,shapeCostDict);
            Assert.AreEqual(total, 14);
        }



    }
}