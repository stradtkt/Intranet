using System;
using System.Linq;
using Intra.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intra.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        private Employee ActiveUser
        {
            get
            {
                return _context.Employees.Where(u => u.EmployeeId == HttpContext.Session.GetInt32("EmployeeId")).FirstOrDefault();
            }
        }

        [HttpGet("employees")]
        public IActionResult Employees()
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login");
            }
            ViewBag.TheUser = ActiveUser;
            ViewBag.Employees = _context.Employees.ToList();
            return View();
        }

        [HttpGet("add-employee-page")]
        public IActionResult AddEmployeePage()
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login");
            }

            ViewBag.TheUser = ActiveUser;
            return View();
        }

        [HttpPost("add-employee")]
        public IActionResult AddEmployee(Employee employee)
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login");
            }
            if (ModelState.IsValid)
                {
                    PasswordHasher<Employee> hasher = new PasswordHasher<Employee>();
                    Employee newEmp = new Employee
                    {
                        EmployeeId = employee.EmployeeId,
                        Name = employee.Name,
                        Email = employee.Email,
                        Image = employee.Image,
                        WorkDept = employee.WorkDept,
                        PhoneNo = employee.PhoneNo,
                        Job = employee.Job,
                        HireDate = employee.HireDate,
                        Sex = employee.Sex,
                        Birthday = employee.Birthday,
                        Salary = employee.Salary,
                        Bonus = employee.Bonus,
                        Password = hasher.HashPassword(employee, employee.Password)
                    };
                    _context.Employees.Add(newEmp);
                    _context.SaveChanges();
                    ViewBag.success = "Employee added!";
                    return RedirectToAction("Employees");
                }
            ViewBag.errors = "Employee was not added, please try again.";
            return View("AddEmployeePage");
        }

        [HttpGet("employee/delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            Employee employee = _context.Employees.Where(e => e.EmployeeId == id).SingleOrDefault();
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Employees");
        }

        [HttpGet("employee/{id}")]
        public IActionResult EmployeeProfilePage(int id)
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login");
            }

            ViewBag.TheUser = ActiveUser;
            ViewBag.User = _context.Employees.Where(u => u.EmployeeId == id).SingleOrDefault();
            return View();
        }

        [HttpGet("employee/edit-page/{id}")]
        public IActionResult EditEmployeePage(int id)
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login");
            }
            ViewBag.TheUser = ActiveUser;
            ViewBag.TheEmp = _context.Employees.Where(e => e.EmployeeId == id).SingleOrDefault();
            return View();
        }

        [HttpPost("employee/edit-page/{id}/edit")]
        public IActionResult EditEmployee(int id, string name, string email, string image, string work, string job,
            DateTime hire, DateTime dob, string sex, decimal salary, decimal bonus)
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login");
            }
            if (ModelState.IsValid)
            {
                Employee employee = _context.Employees.Where(e => e.EmployeeId == id).SingleOrDefault();
                employee.Name = name;
                employee.Email = email;
                employee.Image = image;
                employee.WorkDept = work;
                employee.Job = job;
                employee.HireDate = hire;
                employee.Birthday = dob;
                employee.Sex = sex;
                employee.Salary = salary;
                employee.Bonus = bonus;
                _context.SaveChanges();
                ViewBag.success = "User successfully edited";
                return Redirect("/employee/" + id);
            }
            ViewBag.errors = "Employee was not updated, there was a problem when changing their settings.";
            return Redirect("employee/" + id);
        }
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register-user")]
        public IActionResult RegisterUser(UserViewModel.RegisterUser user)
        {
            Employee checkEmail = _context.Employees.Where(u => u.Email == user.Email).SingleOrDefault();
            if (checkEmail != null)
            {
                ViewBag.errors = "This email already exists";
                return RedirectToAction("Register");
            }

            if (ModelState.IsValid)
            {
                PasswordHasher<UserViewModel.RegisterUser> hasher = new PasswordHasher<UserViewModel.RegisterUser>();
                Employee newUser = new Employee
                {
                    EmployeeId = user.EmployeeId,
                    Name = user.Name,
                    Email = user.Email,
                    Password = hasher.HashPassword(user, user.Password),
                    Birthday = user.Birthday
                };
                _context.Add(newUser);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }

            return View("Register");
        }

        [HttpPost("login-user")]
        public IActionResult LoginUser(UserViewModel.LoginUser user)
        {
            Employee checkEmail = _context.Employees.Where(u => u.Email == user.Email).SingleOrDefault();
            if (checkEmail != null)
            {
                var hasher = new PasswordHasher<Employee>();
                if (0 != hasher.VerifyHashedPassword(checkEmail, checkEmail.Password, user.Password))
                {
                    HttpContext.Session.SetInt32("EmployeeId", checkEmail.EmployeeId);
                    HttpContext.Session.SetString("FirstName", checkEmail.Name);
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    ViewBag.errors = "Incorrect Password";
                    return View("Register");
                }
            }
            else
            {
                ViewBag.errors = "Email not registered";
                return View("Register");
            }
        }
    }
}