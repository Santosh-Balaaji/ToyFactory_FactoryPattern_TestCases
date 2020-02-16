using NUnit.Framework;
using System;
namespace ToyFactoryRefined
{
    [TestFixture]
    public class Tests
    {
        Shape shape;
        Shape redSquare;
        [SetUp]
        public void Setup()
        {
            shape = new Shape();
            redSquare = new Shape("Square","Red",1);
        }

        [Test]
        public void CalculateTotal_EmptyList_Return0()
        {
            var total = Shape.CalculateTotal(shape);
            Assert.AreEqual(total,0);
        }
        [Test]
        public void CalculateTotal_SingleRedSquare_Return2()
        {
            redSquare.ShapeCount = 1;
            var total = Shape.CalculateTotal(redSquare);
            Assert.AreEqual(total, 2);
        }


    }
}