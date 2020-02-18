using System;
using System.Collections.Generic;
using System.Text;

namespace ToyFactory.Reports
{
    public class CuttingReport : IGenerateReport
    {
        public static Order Order { get; set; }

        public CuttingReport(Order order)
        {
            Order = order;
        }
        public void GenerateReport()
        {
            Console.WriteLine("Your cutting list has been generated:");
            DisplayCustomerDetails();
            DisplayCuttingMatrix();
        }

        public static void DisplayCustomerDetails()
        { 
            Console.WriteLine("Name: {0} Address: {1} Due Date: {2} Order #: {3} ", Order.CustomerName, Order.Address, Order.DueDate, Order.OrderID);
        }

        public static void DisplayCuttingMatrix()
        {
            Console.WriteLine("|          | Qty |");
            Console.WriteLine("|----------|-----|");
            foreach (var shape in Enum.GetNames(typeof(EnumerationValues.Shapes)))
            {
                Console.WriteLine("| {0}   | {1} |", shape, Shape.GetTotalNoOfItemsPerShape(Order.ShapeList, shape));
            }
        }
    }
}
