using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DotNetCoreDemo.Models;
namespace DotNetCoreDemo.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository repo;
        public EmployeesController(IEmployeeRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var employeeList = repo.GetEmployees();
            return View(employeeList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee emp)
        {
            repo.Add(emp);
            return RedirectToAction("Index", "Employees");
        }

        public IActionResult Edit(int id)
        {
            var emp = repo.GetEmployeeById(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(int id,Employee emp)
        {
            var updated = repo.Edit(emp);
            if (updated)
                return RedirectToAction("Index", "Employees");
            return View(emp);
        }

        public IActionResult Details(int id)
        {
            var emp = repo.GetEmployeeById(id);
            return View(emp);
        }

        public IActionResult Delete(int id)
        {
            var emp = repo.GetEmployeeById(id);
            if (emp == null)
                return NotFound();
            return View(emp);

        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var emp = repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
