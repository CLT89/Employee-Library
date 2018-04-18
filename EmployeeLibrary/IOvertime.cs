using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeLibrary
{
    public interface IOvertime
    {
        double OvertimeRate
        {
            get;
            set;
        }

        double CalcOvertime(int pHours);
    }
}
