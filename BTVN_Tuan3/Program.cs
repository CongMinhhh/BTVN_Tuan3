using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTVN_Tuan3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int choice;
            do
            {
                Console.WriteLine("\n-----------------------------------------");
                Console.WriteLine("Chọn chức năng muốn sử dụng: ");
                Console.WriteLine("1. Tìm mức lương cao nhất, thấp nhất và mức lương trung bình");
                Console.WriteLine("2. Join, left join, right join");
                Console.WriteLine("3. Tìm Max, min age");
                Console.WriteLine("0. Thoát!");
                Console.Write("Chọn: ");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("-----------------------------------------\n");

                switch (choice)
                {
                    case 1:
                        MaxMinAverageSalary();
                        break;
                    case 2:
                        JoinLeftRightJoin();
                        break;
                    case 3:
                        MaxMinAge();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            } while (choice != 0);

            void MaxMinAverageSalary()
            {
                var employees = Employee.GetEmployees();

                var maxSalary = employees.Max(e => e.Salary);
                var minSalary = employees.Min(e => e.Salary);
                var averageSalary = employees.Average(e => e.Salary);

                Console.WriteLine($"Mức lương cao nhất: {maxSalary}");
                Console.WriteLine($"Mức lương thấp nhất: {minSalary}");
                Console.WriteLine($"Mức lương trung bình: {averageSalary}");
            }

            void JoinLeftRightJoin()
            {
                var departments = Department.GetDepartments();
                var employees = Employee.GetEmployees();

                // Join
                var joinQuery = from e in employees
                                join d in departments on e.DepartmentID equals d.ID
                                select new
                                {
                                    EmployeeName = e.Name,
                                    DepartmentName = d.Name
                                };

                Console.WriteLine("Join:");
                foreach (var item in joinQuery)
                {
                    Console.WriteLine($"{item.EmployeeName} - {item.DepartmentName}");
                }

                // Left join
                var leftJoinQuery = from e in employees
                                    join d in departments on e.DepartmentID equals d.ID into empDept
                                    from d in empDept.DefaultIfEmpty()
                                    select new
                                    {
                                        EmployeeName = e.Name,
                                        DepartmentName = d?.Name
                                    };

                Console.WriteLine("\nLeft join:");
                foreach (var item in leftJoinQuery)
                {
                    Console.WriteLine($"{item.EmployeeName} - {item.DepartmentName}");
                }

                // Right join
                var rightJoinQuery = from d in departments
                                     join e in employees on d.ID equals e.DepartmentID into deptEmp
                                     from e in deptEmp.DefaultIfEmpty()
                                     select new
                                     {
                                         EmployeeName = e?.Name,
                                         DepartmentName = d.Name
                                     };

                Console.WriteLine("\nRight join:");
                foreach (var item in rightJoinQuery)
                {
                    Console.WriteLine($"{item.EmployeeName} - {item.DepartmentName}");
                }
            }

            void MaxMinAge()
            {
                var employees = Employee.GetEmployees();

                var maxAge = employees.Max(e => e.Age);
                var minAge = employees.Min(e => e.Age);

                Console.WriteLine($"Tuổi cao nhất: {maxAge}");
                Console.WriteLine($"Tuổi thấp nhất: {minAge}");
            }
        }
    }
}
