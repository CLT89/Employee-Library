using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeLibrary
{
    [Serializable]
    public class WeeklyPaidEmployee:Employee, IOvertime,IPostHistory
    {
        private double WeeklyPaidEmployeeWeeklyWages;
        private Posts WeeklyPaidEmployeePostHistory;
        private double WeeklyPaidEmployeeOvertimeRate;


        public double WeeklyWages
        {
            get { return WeeklyPaidEmployeeWeeklyWages; }
            set 
            {
                if (value > 1000)
                {
                    throw new WeeklyWageException("Salary is greater than 1000");
                }
                WeeklyPaidEmployeeWeeklyWages = value; 
            }

        }
        public Posts PostHistory
        {
            get { return WeeklyPaidEmployeePostHistory; }
            set { WeeklyPaidEmployeePostHistory = value; }
        }
        public double OvertimeRate
        {
            get { return WeeklyPaidEmployeeOvertimeRate; }
            set { WeeklyPaidEmployeeOvertimeRate = value; }
        }

        public double CalcSalaryAverage()
        {
            double AnnualSalary = 0;
            int NumberOfPosts = 0;
            foreach (Post myPost in WeeklyPaidEmployeePostHistory)
            {
                
                AnnualSalary += myPost.Salary;
                NumberOfPosts++; 

            }
            return AnnualSalary/NumberOfPosts;
        }

        public double CalcSalaryAverage(DateTime pStart, DateTime pEnd)
        {
            double AnnualSalary = 0;
            int NumberOfPosts = 0;
            foreach (Post myPost in WeeklyPaidEmployeePostHistory)
            {
                if (myPost.StartDate >= pStart && myPost.EndDate <= pEnd)
                {
                    AnnualSalary += myPost.Salary;
                    NumberOfPosts++;
                }

            }
            return AnnualSalary/NumberOfPosts;
        }

        public override double CalcWeeklyPay()
        {

            return WeeklyPaidEmployeeWeeklyWages;
        }

          public WeeklyPaidEmployee(string pID, string pName, string pAddress, double pSalary, double pOvertimeRate)//, Posts pPostHistory)
            : base(pID, pName, pAddress)
        {
            if (pSalary > 1000)
            {
                throw new WeeklyWageException("Salary is greater than £1000");
            }
            WeeklyPaidEmployeePostHistory = new Posts();//pPostHistory;
            WeeklyPaidEmployeeWeeklyWages = pSalary;
            WeeklyPaidEmployeeOvertimeRate = pOvertimeRate;

        }

          public double CalcOvertime(int OvertimeHours)
          {
              return WeeklyPaidEmployeeOvertimeRate * OvertimeHours;
          }

        public override string GetStatus()
        {
            return "Weekly Paid Employee";
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("{0:c}", WeeklyPaidEmployeeWeeklyWages).PadRight(4);
        }
    }
}
