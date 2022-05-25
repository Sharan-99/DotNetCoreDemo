using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreDemo.Models
{
   public interface IEmployeeRepository
   {
        List<Employee> GetEmployees();

        Employee GetEmployeeById(int id);
        Employee Add(Employee employee);
        Employee Delete(int id);

        bool Edit(Employee employee);
   }
}
