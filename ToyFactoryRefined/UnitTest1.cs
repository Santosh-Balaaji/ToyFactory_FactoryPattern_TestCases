using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ToyFactoryRefined
{
    [TestFixture]
    public class Tests
    {
        Shape shape;
        Shape redSquare;
        Shape blueSquare;
        Shape redTriangle;
        //Dictionary<string, decimal> shapeCostDict; 
        List<Shape> shapeList; 
        [SetUp]
        public void Setup()
        {
            shape = new Shape();
            redSquare = new Shape("Square","Red",1);
            blueSquare = new Shape("Square", "Blue", 1);
            redTriangle = new Shape("Triangle","Red", 2);
            shapeList = new List<Shape>();
            //shapeCostDict = new Dictionary<string, decimal>();
            //shapeCostDict.Add("Square", 1);
            
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
            shapeList.Add(redSquare);
            redSquare.ShapeCount = 1;
            var total = Shape.CalculateTotal(shapeList);
            Assert.AreEqual(total, 2);
        }

        [Test]
        public void CalculateTotal_RedandBlueSquares_Return3()
        {
            shapeList.Add(redSquare);
            shapeList.Add(blueSquare);
            redSquare.ShapeCount = 1;
            blueSquare.ShapeCount = 1;
            var total = Shape.CalculateTotal(shapeList);
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
            var total = Shape.CalculateTotal(shapeList);
            Assert.AreEqual(total, 6);
        }



    }
}