using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeLibrary
{
    [Serializable]
    public class Post
    {
        private string PostID;
		private string PostName;
		private DateTime PostStartDate;
        private DateTime PostEndDate;
		private double PostSalary;

        public string ID
        {
            get { return PostID; }
            set { PostID = value; }
        }

        public string Name
        {
            get { return PostName; }
            set { PostName = value; }
        }

        public DateTime StartDate
        {
            get { return PostStartDate; }
            set 
            {
                if (value > EndDate)
                {
                    throw new DateException("Start date is after the end date");
                }
                
                PostStartDate = value;
            }
        }

        public DateTime EndDate
        {
            get { return PostEndDate; }
            set 
            {
                if (value < EndDate)
                {
                    throw new DateException("Start date is after the end date");
                }
                PostEndDate = value; 
            }
        }

        public double Salary
        {
            get { return PostSalary; }
            set { PostSalary = value; }
        }

        public Post(string pID, string pName, DateTime pStartDate, DateTime pEndDate, double pSalary)
        {
            if (pStartDate > pEndDate)
            {
                throw new DateException("Start date greater than end date");
            }
            PostID = pID;
            PostName = pName;
            PostStartDate = pStartDate;
            PostEndDate = pEndDate;
            PostSalary = pSalary;
        }

        public Post()
        {
        }

        public string ToString()
        {
            return PostID.PadRight(8) + " " + PostName.PadRight(15) + " " + PostStartDate.ToString("d") + " " + PostEndDate.ToString("d") + " " + String.Format("{0:c}", PostSalary);
        }
    }
}
