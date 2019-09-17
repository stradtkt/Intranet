using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Intra.Models;
using Microsoft.AspNetCore.Http;

namespace Intra.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        public HomeController(DataContext context)
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
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.TheUser = ActiveUser;
            return View();
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login", "Employee");
            }
            ViewBag.TheUser = ActiveUser;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}