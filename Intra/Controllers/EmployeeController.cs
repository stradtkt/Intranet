using System.Linq;
using Intra.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Intra.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        private User ActiveUser
        {
            get
            {
                return _context.Users.Where(u => u.UserId == HttpContext.Session.GetInt32("UserId")).FirstOrDefault();
            }
        }

        [HttpGet("employees")]
        public IActionResult Employees()
        {
            return View();
        }

        [HttpGet("add-employee-page")]
        public IActionResult AddEmployeePage()
        {
            return View();
        }

        [HttpPost("add-employee")]
        public IActionResult AddEmployee(Employee employee, User user)
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login", "User");
            }

            if (ModelState.IsValid)
            {
                Employee newEmp = new Employee
                {
                    Name = employee.Name,
                    Email = user.Email,
                    Image = employee.Image,
                    WorkDept = employee.WorkDept,
                    PhoneNo = employee.PhoneNo,
                    Job = employee.Job,
                    HireDate = employee.HireDate,
                    Sex = employee.Sex,
                    Birthday = user.Birthday,
                    Salary = employee.Salary,
                    Bonus = employee.Bonus
                };
                _context.Employees.Add(newEmp);
                _context.SaveChanges();
                return RedirectToAction("Employees");
            }

            ViewBag.errors = "Employee was not added, please try again.";
            return View("AddEmployeePage");
        }

        [HttpGet("employee/delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            Employee employee = _context.Employees.Where(e => e.EmplyeeId == id).SingleOrDefault();
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Employees");
        }

        [HttpGet("employee/{id}")]
        public IActionResult EmployeeProfilePage(int id)
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login", "User");
            }

            ViewBag.TheUser = ActiveUser;
            ViewBag.User = _context.Employees.Where(u => u.EmplyeeId == id).SingleOrDefault();
            return View();
        }
    }
}