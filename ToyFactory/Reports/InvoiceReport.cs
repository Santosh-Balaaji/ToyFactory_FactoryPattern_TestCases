using System;
using System.Collections.Generic;
using System.Text;

namespace ToyFactory.Reports
{
    public class InvoiceReport : IGenerateReport
    {
        public void GenerateReport(Order order)
        {
            decimal? totalCost = 0;
            Console.WriteLine("# Invoice Report");
            Console.WriteLine("Name: {0}", order.CustomerName);
            Console.WriteLine("Address: {0}", order.Address);
            Console.WriteLine("Due Date: {0}", order.DueDate);
            Console.WriteLine("Order #: {0}", Order.GenerateOrderID());
            Console.WriteLine("|        | {0}  | {1} | {2} |", Enum.GetName(typeof(EnumerationValues.Shapes),0), Enum.GetName(typeof(EnumerationValues.Shapes),1), Enum.GetName(typeof(EnumerationValues.Shapes),2));
            Console.WriteLine("|--------|------|------|--------|");
            Console.WriteLine("| {0} | {1}    | {2}    | {3}      |", Enum.GetName(typeof(EnumerationValues.Color),0), Enum.GetName(typeof(EnumerationValues.Color),1), Enum.GetName(typeof(EnumerationValues.Color),2));

            foreach (var shape in order.ShapeList)
            {
                Console.WriteLine("{0}s             {1} @ ${2} ppi = ${3}", shape.ShapeName, shape.ShapeCount, shape.Cost,Shape.GetTotalCostOfEachShape(order.ShapeList,shape.ShapeName));
            }

            var surchargePrice = Shape.GetSurchargePriceForRed(order.ShapeList);
            Console.WriteLine("Red color surcharge  {0} @ ${1} ppi = ${2}", Shape.GetTotalNumberOfItemsPerColor(order.ShapeList[0][0].Color, order.ShapeList), Shape.SurgePrice, Shape.GetSurchargePriceForRed(order.ShapeList));
            Console.WriteLine("Total : {0}", (totalCost + surchargePrice));

        }
    }
}
