using System;
using System.Collections.Generic;
using System.Text;

namespace ToyFactory.Reports
{
    interface IGenerateReport
    {
        public void GenerateReport(Order order);
    }
}
