using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeLibrary
{
    [Serializable]
    public abstract class Employee
    {
        protected string EmployeeID;
        protected string EmployeeName;
        protected string EmployeeAddress;
       // private double EmployeeSalary;
        //private Posts EmployeePost;

        public string ID
        {
            get { return EmployeeID; }
            set { EmployeeID = value; }
        }

        public string Name
        {
            get { return EmployeeName; }
            set { EmployeeName = value; }
        }

        public string Address
        {
            get { return EmployeeAddress; }
            set { EmployeeAddress = value; }
        }

       /* public double Salary
        {
            get { return EmployeeSalary; }
            set { EmployeeSalary = value; }
        }*/

       /* public Posts Post
        {
            get { return EmployeePost; }
            set { EmployeePost = value; }
        }*/

        public Employee(string pID, string pName, string pAddress) //,double pSalary)
        {
            EmployeeID = pID;
            EmployeeName = pName;
            EmployeeAddress = pAddress;
           // EmployeeSalary = pSalary;
           // EmployeePost = new Posts();
        }

        public Employee()
        {
           //EmployeeSalary = 0;
           // EmployeePost = new Posts();
        }

        public virtual string ToString()
        {
            return EmployeeID.PadRight(8) + "" + EmployeeName.PadRight(22) + "" + EmployeeAddress.PadRight(26); // + "" + String.Format("{0:c}", EmployeeSalary);
        }

        public abstract double CalcWeeklyPay();
      
        public virtual string GetStatus()
        {
            return "Untyped Employee";
        }

        ~Employee()
        {
            Console.WriteLine("Employee object destroyed");
        }
    }
}
