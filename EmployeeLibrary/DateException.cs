using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeLibrary
{
    public class DateException:Exception
    {
        public DateException(string message)
            : base(message)
        {
        }

        public DateException()
        {
        }

        public DateException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
