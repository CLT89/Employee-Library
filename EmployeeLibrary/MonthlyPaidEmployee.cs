using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EmployeeLibrary
{
    [Serializable]
    public class MonthlyPaidEmployee:Employee,IPostHistory
    {
        private double MonthlyPaidEmployeeAnnualSalary;
        private Posts MonthlyPaidEmployeePostHistory;

        public double AnnualSalary
        {
            get { return MonthlyPaidEmployeeAnnualSalary; }
            set 
            {
                if (value < 20000)
                {
                    throw new System.ArgumentException(Convert.ToString(value) + " is less than the lowest possible salary");
                }
                MonthlyPaidEmployeeAnnualSalary = value; 
            }

        }

        public Posts PostHistory
        {
            get { return MonthlyPaidEmployeePostHistory; }
            set { MonthlyPaidEmployeePostHistory = value; }
        }

        public double CalcSalaryAverage()
        {
            
            int NumberOfPosts = 0;
            double AnnualSalary = 0;

            foreach(Post myPost in MonthlyPaidEmployeePostHistory)
            {
                
               AnnualSalary += myPost.Salary;
                NumberOfPosts++;
                
                                               
            }
            
            return AnnualSalary / NumberOfPosts;
        }

        public double CalcSalaryAverage(DateTime pStart, DateTime pEnd)
        {
            
            double AnnualSalary = 0;
            int NumberOfPosts = 0;
            foreach (Post myPost in MonthlyPaidEmployeePostHistory)
            {
                if (myPost.StartDate >= pStart && myPost.EndDate <= pEnd)
                {
                    AnnualSalary += myPost.Salary;
                    NumberOfPosts++;
                }

            }
            
            return AnnualSalary / NumberOfPosts;
        }

        public override double CalcWeeklyPay()
        {
            return MonthlyPaidEmployeeAnnualSalary/52;
        }

        public MonthlyPaidEmployee(string pID, string pName, string pAddress, double pSalary)//, Posts pPostHistory)
            : base(pID, pName, pAddress)
        {
            if (pSalary < 20000)
            {
                throw new System.ArgumentException(Convert.ToString(pSalary) + " is less than the lowest possible salary");
            }
            MonthlyPaidEmployeePostHistory = new Posts();// pPostHistory;
            MonthlyPaidEmployeeAnnualSalary = pSalary;

        }
        public override string GetStatus()
        {

            return "Monthly Paid Employee";
        }

        public override string ToString()
        {

            return base.ToString() + string.Format("{0:c}", MonthlyPaidEmployeeAnnualSalary).PadRight(4);
        }
    }
}
