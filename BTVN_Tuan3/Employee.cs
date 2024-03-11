using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTVN_Tuan3
{
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public DateTime Birthday { get; set; }

        public static List<Employee> GetEmployees()
        {
            return new List<Employee>()
        {
            new Employee { ID = 1, Name = "Đinh Công Minh", DepartmentID = 1, Age = 21, Salary = 20000000, Birthday = new DateTime(2003, 7, 2) },
            new Employee { ID = 2, Name = "D", DepartmentID = 2, Age = 30, Salary = 15000000, Birthday = new DateTime(1992, 2, 2) },
            new Employee { ID = 3, Name = "C", DepartmentID = 3, Age = 27, Salary = 12000000, Birthday = new DateTime(1995, 3, 3) },
            new Employee { ID = 4, Name = "B", DepartmentID = 1, Age = 28, Salary = 11000000, Birthday = new DateTime(1994, 4, 4) },
            new Employee { ID = 5, Name = "E", DepartmentID = 2, Age = 29, Salary = 13000000, Birthday = new DateTime(1993, 5, 5) }
        };
        }
    }
}
