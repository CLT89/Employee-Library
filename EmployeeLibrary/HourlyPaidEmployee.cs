using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeLibrary
{
    [Serializable]
    public class HourlyPaidEmployee:Employee, IOvertime
    {
        protected double HourlyPaidEmployeeRate;
        protected int HourlyPaidEmployeeHours;
        protected double HourlyPaidEmployeeOvertimeRate;

        public double EmployeeRate
        {
            get { return HourlyPaidEmployeeRate; }
            set { HourlyPaidEmployeeRate = value; }
        }

        public int EmployeeHours
        {
            get { return HourlyPaidEmployeeHours; }
            set { HourlyPaidEmployeeHours = value; }
        }
        public double OvertimeRate
        {
            get { return HourlyPaidEmployeeOvertimeRate; }
            set { HourlyPaidEmployeeOvertimeRate = value; }
        }

        public override double CalcWeeklyPay()
        {
            return HourlyPaidEmployeeRate * HourlyPaidEmployeeHours;

        }
        public double CalcOvertime(int OvertimeHours)
        {
            return HourlyPaidEmployeeOvertimeRate * OvertimeHours;
        }
        public HourlyPaidEmployee(string pID, string pName, string pAddress, double pSalary, int pHours, double pOvertimeRate)
            : base(pID, pName, pAddress)
        {

            HourlyPaidEmployeeRate = pSalary;
            HourlyPaidEmployeeHours = pHours;
            HourlyPaidEmployeeOvertimeRate = pOvertimeRate;

        }

        public override string GetStatus()
        {

            return "Hourly Paid Employee";
        }


        public override string ToString()
        {
            return base.ToString() + Convert.ToString(HourlyPaidEmployeeHours).PadRight(4) + string.Format("{0:c}", HourlyPaidEmployeeRate).PadRight(4);
        }
    }
}
