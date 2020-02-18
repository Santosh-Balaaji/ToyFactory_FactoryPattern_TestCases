using System;
using System.Collections.Generic;
using System.Text;

namespace ToyFactory.Reports
{
    public class InvoiceReport : IGenerateReport
    {
        public static Order Order { get; set; }
        public InvoiceReport(Order order)
        {
            Order = order;
        }
        public void GenerateReport()
        {
            DisplayUserDetails();
            DisplayShapeMatrix();
            DisplaySurchagePrices();
            DisplayTotalSurcharge();
        }

        public static void DisplayUserDetails()
        {
            Console.WriteLine("# Invoice Report");
            Console.WriteLine("Name: {0}", Order.CustomerName);
            Console.WriteLine("Address: {0}", Order.Address);
            Console.WriteLine("Due Date: {0}", Order.DueDate);
            Console.WriteLine("Order #: {0}", Order.GenerateOrderID());
        }

        public static void DisplayShapeMatrix()
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

        public static void DisplaySurchagePrices()
        {
            foreach (var shape in Enum.GetNames(typeof(EnumerationValues.Shapes)))
            {
                var totalNoOfShapes = Shape.GetTotalNoOfItemsPerShape(Order.ShapeList, shape);
                var costOfShape = Shape.GetCostOfEachShape(Order.ShapeList, shape);
                Console.WriteLine("{0}s             {1} @ ${2} ppi = ${3}", shape, totalNoOfShapes, costOfShape, totalNoOfShapes * costOfShape);
            }
        }

        public static void DisplayTotalSurcharge()
        {
            decimal? surchargePrice = 0;
            foreach (var shape in Enum.GetNames(typeof(EnumerationValues.Shapes)))
            {
                surchargePrice += Shape.CalculateSurgePriceForEachShape(Order.ShapeList, shape);
            }
            Console.WriteLine("Red color surcharge  {0} @ ${1} ppi = ${2}", Shape.GetTotalNoOfItemsPerColor(Order.ShapeList, "Red"), Shape.SurgePrice, surchargePrice);
            Console.WriteLine("Total : {0}", Shape.CalculateTotal(Order.ShapeList));
        }
    }
}
