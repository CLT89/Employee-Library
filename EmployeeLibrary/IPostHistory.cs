using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeLibrary
{
    public interface IPostHistory
    {
        Posts PostHistory
        {
            get;
            set;
        }

        double CalcSalaryAverage();

        double CalcSalaryAverage(DateTime pStart, DateTime pEnd);


    }
}
