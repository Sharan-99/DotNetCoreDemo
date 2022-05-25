using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreDemo.Models
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private List<Employee> emplist;
        public EmployeeRepository()
        {
            emplist = new List<Employee>()
            { 
                new Employee(){Id=101,Name="Sharan",Email="sharan@gmail.com",Location="Chennai"},
                new Employee(){Id=102,Name="Naveen",Email="naveen@gmail.com",Location="Coimbatore"},
                new Employee(){Id=103,Name="Arun",Email="arun@gmail.com",Location="Hyderabad"},
                new Employee(){Id=104,Name="Tharun",Email="tharun@gmail.com",Location="Chennai"},

            };
        }
        public List<Employee> GetEmployees()
        {
            return emplist;
        }

        public Employee GetEmployeeById(int id)
        {
            var emp = emplist.FirstOrDefault(e=>e.Id == id);
            return emp;
        }
        public Employee Add(Employee employee)
        {
            employee.Id = emplist.Max(e => e.Id) + 1;
            emplist.Add(employee);
            return employee;
        }
        public Employee Delete(int id)
        {
            var emp = emplist.FirstOrDefault(e => e.Id == id);
            if (emp != null)
                emplist.Remove(emp);

            return emp;
        }

        public bool Edit(Employee employee)
        {
            //var record = emplist.First(e=>e.Id==employee.Id);
            var record = GetEmployeeById(employee.Id);
            record.Name = employee.Name;
            record.Email = employee.Email;
            record.Location = employee.Location;
            return true;
        }
    }
}
