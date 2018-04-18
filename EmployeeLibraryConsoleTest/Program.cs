using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeLibrary;
using System.IO;

namespace EmployeeLibraryConsoleTest
{
    public class Program
    {
        static Business myBusiness = new Business();
        //static Employees myEmployees = new Employees();

        static void Main(string[] args)
        {
            string choice;

            do
            {
                Console.WriteLine("Employee LIBRARY TEST PROGRAM");
                Console.WriteLine();

                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Add Post");
                Console.WriteLine("3. Calculate Weekly Pay");
                Console.WriteLine("4. Calculate Total Weekly Pay");
                Console.WriteLine("5. Display individual Employee");
                Console.WriteLine("6. Display all Employees");
                Console.WriteLine("7. Display all Post History");
                Console.WriteLine("8. Calculate Average Salary");
                Console.WriteLine("9. Calculate Average Overtime Rate");
                Console.WriteLine("10. Remove Employee");
                Console.WriteLine("11. Remove Post");                
                Console.WriteLine("12. Load Employees");
                Console.WriteLine("13. Save Employees");
                Console.WriteLine("14. Total Weekly Bill");
                Console.WriteLine();

                Console.WriteLine("20. Exit");

                Console.WriteLine();
                choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddEmpl();
                        break;
                    case "2":
                        AddPost();
                        break;
                    case "3":
                        WeeklyPay();
                        break;
                    case "4":
                        CalcTotalWeeklyPay();
                        break;
                    case "5":
                        Display();
                        break;
                    case "6":
                        DisplayAll();
                        break;
                    case "7":
                        DisplayAllPostHistory();
                        break;
                    case "8":
                        CalcAverage();
                        break;
                    case "9":
                        CalcAverageOvertimeRate();
                        break;
                    case "10":
                        RemoveEmployee();
                        break;
                    case "11":
                        RemovePost();
                        break;
                    case "12":
                        Load();
                        break;
                    case "13":
                        Save();
                        break;
                    case "14":
                        CalcTotalWeeklyBill();
                        break;

                    case "20":
                        break;
                }

                Console.WriteLine();
            } while (choice != "20");

        }

        static void AddEmpl()
        {
            string myType;
            string myID;
            string myName;
            string myAddress;        
            double mySalary;
            double mySalaryRate;
            int myHours;
            double myOvertimeRate;        
            DateTime myStart;
            DateTime myEnd;

            Console.WriteLine("Add Employee");
            Console.WriteLine();
            Console.Write("Type M/W/H:");
            myType = Console.ReadLine();
            Console.Write("ID: ");
            myID = Console.ReadLine();
            Console.Write("Name: ");
            myName = Console.ReadLine();
            Console.Write("Address: ");
            myAddress = Console.ReadLine();
            //Console.Write("Salary: ");
            //mySalary = Convert.ToDouble(Console.ReadLine());
            

            if (myType == "M")
            {
                try
                {
                    Console.Write("Salary:");
                    mySalary = Convert.ToDouble(Console.ReadLine());
                    Posts myPostHistory = new Posts();

                    MonthlyPaidEmployee myEmployee = new MonthlyPaidEmployee(myID, myName, myAddress, mySalary);//, myPostHistory);
                    myBusiness.AddEmployee(myID, myEmployee);
                    //myEmployees.Add(myID, myEmployee);
                    Console.WriteLine();
                    Console.Write("Employee Entered; press any key to continue.");
                    Console.ReadLine();
                }
                catch (ArgumentException ex) 
                {
                    Console.WriteLine("Salary is less than £20000");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    Console.WriteLine("Press Any Key to continue");
                    Console.ReadLine();
                }
            }
            else if (myType == "W")
            {
                try
                {
                    Console.Write("Salary:");
                    mySalary = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Overtime Rate: ");
                    myOvertimeRate = Convert.ToDouble(Console.ReadLine());
                    Posts myPostHistory = new Posts();
                    WeeklyPaidEmployee myEmployee = new WeeklyPaidEmployee(myID, myName, myAddress, mySalary, myOvertimeRate);//, myPostHistory);
                    myBusiness.AddEmployee(myID, myEmployee);
                    //myEmployees.Add(myID, myEmployee);
                    Console.WriteLine();
                    Console.Write("Employee Entered; press any key to continue.");
                    Console.ReadLine();
                }
                catch (WeeklyWageException ex)
                {
                    Console.WriteLine("Salary is greater than £1000");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    Console.WriteLine("Press Any Key to continue");
                    Console.ReadLine();
                }
            }
            else if (myType == "H")
            {
                Console.Write("Temporary Y/N: ");
                myType = Console.ReadLine();
                Console.Write("Salary Rate: ");
                mySalaryRate = Convert.ToDouble(Console.ReadLine());
                Console.Write("Hours: ");
                myHours = Convert.ToInt16(Console.ReadLine());
                Console.Write("Overtime Rate: ");
                myOvertimeRate = Convert.ToDouble(Console.ReadLine());
                if (myType == "N")
                {
                    
                    HourlyPaidEmployee myEmployee = new HourlyPaidEmployee(myID, myName, myAddress, mySalaryRate, myHours, myOvertimeRate);
                    myBusiness.AddEmployee(myID, myEmployee);
                    //myEmployees.Add(myID, myEmployee);
                }
                else if (myType == "Y")
                {
                    
                    Console.Write("Start Date: ");
                    myStart = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("End Date: ");
                    myEnd = Convert.ToDateTime(Console.ReadLine());

                    TemporaryHourlyPaidEmployee myEmployee = new TemporaryHourlyPaidEmployee(myID, myName, myAddress, mySalaryRate, myHours, myOvertimeRate, myStart, myEnd);
                    myBusiness.AddEmployee(myID, myEmployee);
                    //myEmployees.Add(myID, myEmployee);
                }
                Console.WriteLine();
                Console.Write("Employee Entered; press any key to continue.");
                Console.ReadLine();
               
            }
           
           // Employee myEmployee = new Employee(myID, myName, myAddress);//, mySalary);
           
            
            //Console.WriteLine(myEmployee.ToString());
           
        }
         static void AddPost()
        {
            string myEID;
            string myID;
            string myName;
            //string myType;
            DateTime myStartDate;
            DateTime myEndDate;
            double mySalary;
            IPostHistory myPostHistory;
            Employee myEmployee;
            Employees myEmployees = myBusiness.Employees;
            //MonthlyPaidEmployee myMonthlyPaidEmployee;
            //WeeklyPaidEmployee myWeeklyPaidEmployee;

            Console.WriteLine("Add Post");
            Console.WriteLine();

            //Console.Write("Is Employee Monthly or Weekly (Y/N):");
           // myType = Console.ReadLine();


            try
            {

                //if (myType == "Y")
                //{
                Console.Write("Employee ID: ");
                myEID = Console.ReadLine();
                //myEmployee = myBusiness.Employees[myEID];
                myEmployee = myEmployees[myEID];
                myEmployee.ToString();


                if (myEmployee is MonthlyPaidEmployee || myEmployee is WeeklyPaidEmployee)
                {
                    Console.Write("Post ID: ");
                    myID = Console.ReadLine();
                    Console.Write("Post Name: ");
                    myName = Console.ReadLine();
                    Console.Write("Start Date: ");
                    myStartDate = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("End Date: ");
                    myEndDate = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Salary: ");
                    mySalary = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();

                    Post myPost = new Post(myID, myName, myStartDate, myEndDate, mySalary);
                    myPostHistory = (IPostHistory)myBusiness.Employees[myEID];
                    myBusiness.AddPost(myEID, myPostHistory, myPost);
                    
                    //myPostHistory.PostHistory.Add(myID, myPost);

                    Console.Write("Post Entered; press any key to continue.");
                    Console.ReadLine();
                }
                /*else
                {
                    Console.Write("Employee is not Monthly or Weekly; Press any key to continue");
                    Console.ReadLine();
                }*/
            }

            catch (NullReferenceException ex)
            {
                Console.WriteLine("Employee ID missing or invalid; see below for more details");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine("Press Any Key to continue");
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Either one of the Dates or the Salary was entered in the wrong format; see below for more details");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine("Press Any Key to continue");
                Console.ReadLine();
            }
            catch (DateException ex)
            {
                Console.WriteLine("Dates entered are invalid; see below for details");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine("Press Any Key to continue");
                Console.ReadLine();
            }

            catch
            {
                Console.WriteLine("Unforeseen Error");
                Console.WriteLine();
                Console.WriteLine("Press Any Key to continue");
                Console.ReadLine();
            }
            //}
            /*else
            {                
                Console.Write("Press any key to continue.");
                Console.ReadLine();
            }*/

           //myEmployees[myEID].Post.Add(myID, myPost);
            
            //Console.WriteLine(myEmployees[myEID].Post[myID].ToString());

            
        }

       /* static void AddPostToEmpl()
        {
            Console.WriteLine("Add Post to Employee");
            Console.WriteLine();
            
            myEmployee.Post.ID = myPost.ID;
            myEmployee.Post.Name = myPost.Name;
            myEmployee.Post.StartDate = myPost.StartDate;
            myEmployee.Post.EndDate = myPost.EndDate;
            myEmployee.Post.Salary = myPost.Salary;

            Console.WriteLine(myEmployee.Post.ToString());

            Console.Write("Post Added to Employee; press any key to continue.");
            Console.ReadLine();
        }*/

        static void WeeklyPay()
        {
            string myEID;
            Employee myEmployee;


            Console.Write("Employee ID:");
            myEID = Console.ReadLine();
            //myEmployee = myEmployees[myEID];
            myEmployee = myBusiness.Employees[myEID];
            Console.WriteLine("Weekly Pay:" + myEmployee.CalcWeeklyPay());
            Console.WriteLine();
            Console.Write("Press any key to continue.");
            Console.ReadLine();
            

        }

        static void Display()
        {
            string myEID;
            Employee myEmployee;            
           
            Console.WriteLine("Display Employee");
            Console.WriteLine();
            try
            {

                Console.Write("Employee ID: ");
                myEID = Console.ReadLine();
                myEmployee = myBusiness.Employees[myEID];
                //myEmployee = myEmployees[myEID];
                Console.WriteLine(myEmployee.ToString());
                


                Console.WriteLine();

                Console.Write("Press any key to continue.");
                Console.ReadLine();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Employee does not exist; see below for more details");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine("Press Any Key to continue");
                Console.ReadLine();
            }

        }

        static void DisplayAllPostHistory()
        {
            IPostHistory myPostHistory;
            Employees myEmployees = myBusiness.Employees;
            Console.WriteLine("Display All Post History");
            Console.WriteLine();
            

            foreach (Employee myEmployee in myEmployees)
            {
                if (myEmployee is IPostHistory)
                {
                    Console.WriteLine(myEmployee.ToString() + "\n");
                    Console.WriteLine(myEmployee.GetStatus());
                    myPostHistory = (IPostHistory)myEmployee;

                    
                    foreach (Post myPost in myPostHistory.PostHistory)
                    {
                        
                        Console.Write("\t" + myPost.ToString() + "\n");
                    }
                   
                }

                
            }

            Console.WriteLine();
            Console.Write("Press any key to continue.");
            Console.ReadLine();
        }

        static void CalcAverageOvertimeRate()
        {
            IOvertime myOvertime;
            double myOvertimeRate = 0;            
            int overtimeEmployees = 0;
            Employees myEmployees = myBusiness.Employees;
            Console.WriteLine("Calculate Average Overtime Rate");
            Console.WriteLine();

            foreach (Employee myEmployee in myEmployees)
            {
                if (myEmployee is IOvertime)
                {
                    
                    myOvertime = (IOvertime)myEmployee;
                    myOvertimeRate += myOvertime.OvertimeRate;
                    overtimeEmployees++;
                }
            }
            
            Console.WriteLine(myOvertimeRate / overtimeEmployees);
            Console.WriteLine();
            Console.Write("Press any key to continue.");
            Console.ReadLine();

        }
            
        static void DisplayAll()
        {
            IPostHistory myPostHistory;
            //Employees myEmployees = myBusiness.Employees;
            Console.WriteLine("Display All Employees");
            Console.WriteLine();

            foreach (Employee myEmployee in myBusiness.Employees)
            {
                Console.WriteLine(myEmployee.ToString() + "\n");
                Console.WriteLine("Weekly Pay: " + myEmployee.CalcWeeklyPay());
                Console.WriteLine("Status: " + myEmployee.GetStatus());
                if (myEmployee is IPostHistory)
                {
                    //Console.WriteLine(myEmployee.ToString() + "\n");
                    //Console.WriteLine(myEmployee.GetStatus());
                    myPostHistory = (IPostHistory)myEmployee;
                    Console.WriteLine("Post History:");

                    foreach (Post myPost in myPostHistory.PostHistory)
                    {

                        Console.Write("\t" + myPost.ToString() + "\n");
                    }
                    Console.WriteLine();
                }
            }

            Console.Write("Press any key to continue.");
            Console.ReadLine();
        }

        static void Load()
        {
            //Employees myEmployees = myBusiness.Employees;
            try
            {
                //myEmployees = FileOps.LoadBusiness("myEmployees.bin");
                myBusiness.LoadBusiness("myEmployees.bin");
                Console.Write("Business loaded; press any key to continue.");
                Console.ReadLine();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found; see below for details");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine("Press Any Key to continue");
                Console.ReadLine();
            }
        }

        static void Save()
        {
            //Employees myEmployees = myBusiness.Employees;
            //FileOps.SaveBusiness("myEmployees.bin", myEmployees);
            myBusiness.SaveBusiness("myEmployees.bin");

            Console.Write("Business saved; press any key to continue.");
            Console.ReadLine();
        }

        static void RemoveEmployee()
        {
            string myEID;

            Console.Write("Employee ID: ");
            myEID = Console.ReadLine();
            myBusiness.RemoveEmployee(myEID);
            //myEmployees.Remove(myEID);
            Console.WriteLine();
            Console.Write("Employee Removed; Press any key to continue.");
            Console.ReadLine();
            
        }
        static void RemovePost()
        {
            string myPID;
            string myEID;
            Employee myEmployee;
            IPostHistory myPostHistory;
            
            

            Console.Write("Employee ID: ");
            myEID = Console.ReadLine();
            //myEmployee = myEmployees[myEID];
            myEmployee = myBusiness.Employees[myEID];
            if (myEmployee is IPostHistory)
            {
                Console.Write("Post ID: ");
                myPID = Console.ReadLine();
                myPostHistory = (IPostHistory)myBusiness.Employees[myEID];
                //myPostHistory.PostHistory.Remove(myPID);
                myBusiness.RemovePost(myEID, myPID, myPostHistory);
                Console.WriteLine();
                Console.Write("Post Removed; Press any key to continue.");
                Console.ReadLine();

            }
      
            
        }

        static void CalcAverage()
        {
            double myPostAverage = 0;
            int numOfEmployees = 0;        
            IPostHistory myPostHistory;
            //Employees myEmployees = myBusiness.Employees;

            foreach (Employee myEmployee in myBusiness.Employees)
            {
                if (myEmployee is IPostHistory)
                {
                    myPostHistory = (IPostHistory)myEmployee;
                    myPostAverage += myPostHistory.CalcSalaryAverage();
                    numOfEmployees++;                    
                                    
                }
            }
            Console.WriteLine("AverageSalary:" + myPostAverage / numOfEmployees);
            Console.WriteLine();
            Console.Write("Press any key to continue.");
            Console.ReadLine();

        }

        static void CalcTotalWeeklyPay()
        {
            double myWeeklyPay = 0;
            

            foreach (Employee myEmployee in myBusiness.Employees)
            {
                if (myEmployee is HourlyPaidEmployee)
                {
                    myWeeklyPay += myEmployee.CalcWeeklyPay();

                }
            }

            Console.WriteLine("Total Weekly pay:" + myWeeklyPay);
            Console.WriteLine();
            Console.Write("Press any key to continue.");
            Console.ReadLine();

        }

        static void CalcTotalWeeklyBill()
        {
            double weeklyBill;
            Console.WriteLine("Total weekly bill:");
            
            weeklyBill = myBusiness.TotalWeeklyBill();
            Console.WriteLine(weeklyBill);
            Console.WriteLine("Press any key to continue");
        }
    }
}
