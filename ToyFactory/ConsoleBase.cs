using System;
using System.Collections.Generic;
using System.Text;
using ToyFactory.Factories;
using ToyFactory.Reports;

namespace ToyFactory
{
    public class ConsoleBase
    {
        public ConsoleBase()
        {
            var order = GetUserDetails();
            order.ShapeList = GenerateShapeListFromFactory();


        }

        public static Order GetUserDetails()
        {
            Order order = new Order();
            Console.WriteLine("### Example input");
            Console.WriteLine("~~~");
            Console.WriteLine("Welcome to the Toy Block Factory!");

            Console.WriteLine("Please input your Name:");
            order.CustomerName = Console.ReadLine();

            Console.WriteLine("Please input your Address:");
            order.Address = Console.ReadLine();

            Console.WriteLine("Please input your Due Date");
            order.DueDate = Console.ReadLine();
            return order;
        }

        public static List<Shape> GenerateShapeListFromFactory()
        {
            var factories = GenerateFactoryParameters();
            var shapeList = ConcreteShapeFactory.GenerateShapeList(factories);

            return shapeList;
        }

        public static Dictionary<string, ShapeFactory> GenerateFactoryParameters()
        {
            var factories = new Dictionary<string, ShapeFactory>();
            factories.Add("Square", new SquareFactory());
            factories.Add("Circle", new CircleFactory());
            factories.Add("Triangle", new TriangleFactory());

            return factories;

        }
    }
}
