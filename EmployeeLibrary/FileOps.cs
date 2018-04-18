using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace EmployeeLibrary
{
    public static class FileOps
    {
        public static void SaveBusiness(string pFileName, Employees pEmployees)
        {
            IFormatter Serializer = new BinaryFormatter();
            FileStream SaveFile = new FileStream(pFileName, FileMode.Create, FileAccess.Write);

            Serializer.Serialize(SaveFile, pEmployees);
            SaveFile.Close();
        }

        public static Employees LoadBusiness(string pFileName)
        {
            Employees myEmployees;
            
            IFormatter Serialize = new BinaryFormatter();
            FileStream LoadFile = new FileStream(pFileName, FileMode.Open, FileAccess.Read);

            myEmployees = Serialize.Deserialize(LoadFile) as Employees;
            LoadFile.Close();

            return myEmployees;
        }
    }
}
