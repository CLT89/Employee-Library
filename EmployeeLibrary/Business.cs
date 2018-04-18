using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EmployeeLibrary
{
    public class Business
    {
        private Employees myEmployees;

        public Employees Employees
        {
            get { return myEmployees; }
        }

        public Business()
        {
            myEmployees = new Employees();
        }

        public void AddEmployee(string pID, Employee pEmployee)
        {
            myEmployees.Add(pID, pEmployee);
        }

        public void RemoveEmployee(string pID)
        {
            myEmployees.Remove(pID);
        }

        public void AddPost(string pEID, IPostHistory pPostHistory, Post pPost)
        {
            //pEmployee = myEmployees[pEID];
            pPostHistory = (IPostHistory)myEmployees[pEID];
            pPostHistory.PostHistory.Add(pEID, pPost);
        }

        public void RemovePost(string pEID, string pPID, IPostHistory pPostHistory)
        {
            //pEmployee = myEmployees[pEID];
            pPostHistory = (IPostHistory)myEmployees[pEID];
            pPostHistory.PostHistory.Remove(pPID);
        }

        public Employee SelectEmployee(string pID)
        {
            return myEmployees[pID];
        }

        public void SaveBusiness(string pEmplFile)
        {
            IFormatter Serializer = new BinaryFormatter();
            FileStream SaveEmpl = new FileStream(pEmplFile, FileMode.Create, FileAccess.Write);

            Serializer.Serialize(SaveEmpl, myEmployees);
            SaveEmpl.Close();
        }

        public void LoadBusiness(string pEmplFile)
        {
            IFormatter Serialize = new BinaryFormatter();
            FileStream LoadEmpl = new FileStream(pEmplFile, FileMode.Open, FileAccess.Read);

            myEmployees = Serialize.Deserialize(LoadEmpl) as Employees;
            LoadEmpl.Close();
        }

        public Employees ReturnMonthly()
        {
            Employees rEmployees = new Employees();

            foreach (Employee myEmployee in myEmployees)
            {
                if (myEmployee is MonthlyPaidEmployee)
                {
                    rEmployees.Add(myEmployee.ID, myEmployee);
                }
            }

            return rEmployees;
        }

        public Employees PostHistory()
        {
            Employees rEmployees = new Employees();

            foreach (Employee myEmployee in myEmployees)
            {
                if (myEmployee is IPostHistory)
                {
                    rEmployees.Add(myEmployee.ID, myEmployee);
                }
            }

            return rEmployees;
        }

        public double TotalWeeklyBill()
        {
            double totalSalary = 0;
            foreach (Employee myEmployee in Employees)
            {
                totalSalary += myEmployee.CalcWeeklyPay();
            }

            return totalSalary;
        }
    }
}
