using System;
using System.Collections.Generic;
using System.Text;

namespace ToyFactory.Reports
{
    public class InvoiceReport : IGenerateReport
    {
        public void GenerateReport(Order order)
        {
            decimal? surchargePrice = 0;
            Console.WriteLine("# Invoice Report");
            Console.WriteLine("Name: {0}", order.CustomerName);
            Console.WriteLine("Address: {0}", order.Address);
            Console.WriteLine("Due Date: {0}", order.DueDate);
            Console.WriteLine("Order #: {0}", Order.GenerateOrderID());
            Console.WriteLine("|        | {0}  | {1} | {2} |", Enum.GetName(typeof(EnumerationValues.Color),0), Enum.GetName(typeof(EnumerationValues.Color),1), Enum.GetName(typeof(EnumerationValues.Color),2));
            Console.WriteLine("|--------|------|------|--------|");
            foreach (var shape in Enum.GetNames(typeof(EnumerationValues.Shapes)))
            {
                Console.WriteLine("| {0} | {1}    | {2}    | {3}      |", 
                    shape, 
                    Shape.GetTotalNoOfItemsPerShapeandColor(order.ShapeList,shape, Enum.GetName(typeof(EnumerationValues.Color), 0)), 
                    Shape.GetTotalNoOfItemsPerShapeandColor(order.ShapeList, shape, Enum.GetName(typeof(EnumerationValues.Color), 1)),
                    Shape.GetTotalNoOfItemsPerShapeandColor(order.ShapeList, shape, Enum.GetName(typeof(EnumerationValues.Color), 2))
                    );

            }

            foreach (var shape in Enum.GetNames(typeof(EnumerationValues.Shapes)))
            {
                surchargePrice += Shape.CalculateSurgePriceForRedShapes(order.ShapeList,shape);
                var totalNoOfShapes = Shape.GetTotalNoOfItemsPerShape(order.ShapeList, shape.ShapeName);
                Console.WriteLine("{0}s             {1} @ ${2} ppi = ${3}", shape.ShapeName, totalNoOfShapes, shape.Cost,totalNoOfShapes*shape.Cost);
            }
            Console.WriteLine("Red color surcharge  {0} @ ${1} ppi = ${2}", Shape.GetTotalNoOfItemsPerColor(order.ShapeList,"Red"), Shape.SurgePrice, surchargePrice);
            Console.WriteLine("Total : {0}", Shape.CalculateTotal(order.ShapeList));

        }
    }
}
