using System;
using System.Collections.Generic;
using System.Text;
using ToyFactory.Reports;

namespace ToyFactory
{
    public class ConsoleBase
    {
        public ConsoleBase()
        {
            var order = GetUserDetails();
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
    }
}
