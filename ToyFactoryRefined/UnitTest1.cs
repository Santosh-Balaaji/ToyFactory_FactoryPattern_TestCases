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
        //Dictionary<string, decimal> shapeCostDict; 
        List<Shape> squareList; 
        [SetUp]
        public void Setup()
        {
            shape = new Shape();
            redSquare = new Shape("Square","Red",1);
            blueSquare = new Shape("Square", "Blue", 1);
            squareList = new List<Shape>();
            //shapeCostDict = new Dictionary<string, decimal>();
            //shapeCostDict.Add("Square", 1);
            
        }

        [Test]
        public void CalculateTotal_EmptyList_Return0()
        {
            var total = Shape.CalculateTotal(squareList);
            Assert.AreEqual(total,0);
        }
        [Test]
        public void CalculateTotal_SingleRedSquare_Return2()
        {
            squareList.Add(redSquare);
            redSquare.ShapeCount = 1;
            var total = Shape.CalculateTotal(squareList);
            Assert.AreEqual(total, 2);
        }

        [Test]
        public void CalculateTotal_RedandBlueSquares_Return3()
        {
            squareList.Add(redSquare);
            squareList.Add(blueSquare);
            redSquare.ShapeCount = 1;
            blueSquare.ShapeCount = 1;
            var total = Shape.CalculateTotal(squareList);
            Assert.AreEqual(total, 3);
        }



    }
}