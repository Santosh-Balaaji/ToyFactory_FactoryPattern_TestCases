using System;
using System.Collections.Generic;
using System.Text;

namespace ToyFactory.Reports
{
    public class PaintingReport : IGenerateReport
    {
        public static Order Order { get; set; }

        public PaintingReport(Order order)
        {
            Order = order;
        }
        public void GenerateReport()
        {
            Console.WriteLine("Your painting report has been generated:");
            DisplayUserDetails();
            DisplayPaintingMatrix();
        }
        public static void DisplayUserDetails()
        {
            Console.WriteLine("Name: {0} Address: {1} Due Date: {2} Order #: {3}", Order.CustomerName, Order.Address, Order.DueDate, Order.OrderID);
        }

        public static void DisplayPaintingMatrix()
        {
            Console.WriteLine("|        | {0}  | {1} | {2} |", Enum.GetName(typeof(EnumerationValues.Color), 0), Enum.GetName(typeof(EnumerationValues.Color), 1), Enum.GetName(typeof(EnumerationValues.Color), 2));
            Console.WriteLine("|--------|------|------|--------|");
            foreach (var shape in Enum.GetNames(typeof(EnumerationValues.Shapes)))
            {
                Console.WriteLine("| {0} | {1}    | {2}    | {3}      |",
                    shape,
                    Shape.GetTotalNoOfItemsPerShapeandColor(Order.ShapeList, shape, Enum.GetName(typeof(EnumerationValues.Color), 0)),
                    Shape.GetTotalNoOfItemsPerShapeandColor(Order.ShapeList, shape, Enum.GetName(typeof(EnumerationValues.Color), 1)),
                    Shape.GetTotalNoOfItemsPerShapeandColor(Order.ShapeList, shape, Enum.GetName(typeof(EnumerationValues.Color), 2))
                    );

            }
        }
    }
}
