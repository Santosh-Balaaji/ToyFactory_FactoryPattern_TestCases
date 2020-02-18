using System;
using System.Collections.Generic;
using System.Text;

namespace ToyFactory.Reports
{
    public class PaintingReport : IGenerateReport
    {
        public void GenerateReport(Order order)
        {
            Console.WriteLine("Your painting report has been generated:");
            Console.WriteLine("Name: {0} Address: {1} Due Date: {2} Order #: {3}", order.CustomerName, order.Address, order.DueDate, Order.OrderID);
            Console.WriteLine("|        | {0}  | {1} | {2} |", Enum.GetName(typeof(EnumerationValues.Color), 0), Enum.GetName(typeof(EnumerationValues.Color), 1), Enum.GetName(typeof(EnumerationValues.Color), 2));
            Console.WriteLine("|--------|------|------|--------|");
            foreach (var shape in Enum.GetNames(typeof(EnumerationValues.Shapes)))
            {
                Console.WriteLine("| {0} | {1}    | {2}    | {3}      |",
                    shape,
                    Shape.GetTotalNoOfItemsPerShapeandColor(order.ShapeList, shape, Enum.GetName(typeof(EnumerationValues.Color), 0)),
                    Shape.GetTotalNoOfItemsPerShapeandColor(order.ShapeList, shape, Enum.GetName(typeof(EnumerationValues.Color), 1)),
                    Shape.GetTotalNoOfItemsPerShapeandColor(order.ShapeList, shape, Enum.GetName(typeof(EnumerationValues.Color), 2))
                    );

            }
        }
    }
}
