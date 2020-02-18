using System;
using System.Collections.Generic;
using System.Text;
using ToyFactory.Factories;
using ToyFactory.Reports;

namespace ToyFactory
{
    public class ConsoleBase
    {
         public  ConsoleBase()
         {
            var order = GetUserDetails();
            order.ShapeList = GenerateShapeListFromFactory();
            GetShapeDetailsFromUser(order.ShapeList);

            InvoiceReport invoice = new InvoiceReport(order);
            invoice.GenerateReport();
            CuttingReport cuttingReport = new CuttingReport(order);
            cuttingReport.GenerateReport();
            PaintingReport paintingReport = new PaintingReport();
            paintingReport.GenerateReport(order);
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
            foreach (var action in Enum.GetValues(typeof(EnumerationValues.Shapes)))
            {
                var factory = (ShapeFactory)Activator.CreateInstance(Type.GetType("ToyFactory.Factories."+Enum.GetName(typeof(EnumerationValues.Shapes),action)+"Factory"));
                factories.Add(Enum.GetName(typeof(EnumerationValues.Shapes), action), factory);
            }

            return factories;
        }

        public static void GetShapeDetailsFromUser(List<Shape> shapeList)
        {
            foreach (var item in shapeList)
            {
                Console.WriteLine("Please input the number of {0} {1}s", item.Color, item.ShapeName);
                Int32.TryParse(Console.ReadLine(), out int count);
                item.ShapeCount = count;
            }
        }
    }
}
