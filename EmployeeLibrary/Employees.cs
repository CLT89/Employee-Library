using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeLibrary
{
    [Serializable]    
    public class Employees : DictionaryBase
    {
        public Employees()
        {
        }

        public void Add(string pEmpID, Employee pEmployee)
        {
            Dictionary.Add(pEmpID, pEmployee);
        }

        public void Remove(string pEmpID)
        {
            Dictionary.Remove(pEmpID); 
        }

        public Employee this[string pEmpID]
        {
            get
            {
                try
                {
                    return (Employee)Dictionary[pEmpID];
                }
                catch (NullReferenceException ex)
                {
                    throw;
                }
            }
            set
            {
                Dictionary[pEmpID] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (object employee in Dictionary.Values)
                yield return (Employee)employee;
        }
    }
}
