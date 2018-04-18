using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeLibrary
{
    [Serializable]
    public class TemporaryHourlyPaidEmployee:HourlyPaidEmployee
    {
        private DateTime TemporaryHourlyPaidEmployeeStart;
        private DateTime TemporaryHourlyPaidEmployeeEnd;

        public DateTime EmployeeStart
        {
            get { return TemporaryHourlyPaidEmployeeStart; }
            set { TemporaryHourlyPaidEmployeeStart = value; }
        }

        public DateTime EmployeeEnd
        {
            get { return TemporaryHourlyPaidEmployeeEnd; }
            set { TemporaryHourlyPaidEmployeeEnd = value; }
        }

        public override string ToString()
        {
            return base.ToString() + TemporaryHourlyPaidEmployeeStart.ToString("d").PadRight(12) + TemporaryHourlyPaidEmployeeEnd.ToString("d");
        }

        public override string GetStatus()
        {
            return "Temporary Hourly Paid Employee";
        }

        public TemporaryHourlyPaidEmployee(string pID, string pName, string pAddress, double pSalary, int pHours, double pOvertimeRate, DateTime pStart, DateTime pEnd)
            : base(pID, pName, pAddress, pSalary, pHours, pOvertimeRate)
        {

            TemporaryHourlyPaidEmployeeStart = pStart;
            TemporaryHourlyPaidEmployeeEnd = pEnd;

        }
    }
}
