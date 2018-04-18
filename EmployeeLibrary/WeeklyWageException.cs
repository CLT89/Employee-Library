using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeLibrary
{
    public class WeeklyWageException:Exception
    {
        public WeeklyWageException(string message)
            : base(message)
        {
        }

        public WeeklyWageException()
        {
        }

        public WeeklyWageException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
