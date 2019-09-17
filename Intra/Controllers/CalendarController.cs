
using System;
using System.Collections.Generic;
using System.Linq;
using Intra.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Intra.Controllers
{
    public class CalendarController : Controller
    {
        private readonly DataContext _context;

        public CalendarController(DataContext context)
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

        [HttpGet("calendar")]
        public IActionResult Calendar()
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login", "Employee");
            }
            return View(new Calendar());
        }

        public JsonResult GetEvents(DateTime start, DateTime end, string title, Employee employee)
        {
            var viewModel = new Calendar();
            var events = new List<Calendar>();
            start = DateTime.Today;
            end = DateTime.Today;
            for(var i = 1; i <= 5; i++)
            {
                events.Add(new Calendar()
                {
                    CalendarId = i,
                    Title = title,
                    Start = start.ToString(),
                    End = end.ToString(),
                    EmployeeId = employee.EmployeeId
                });
                start = start.AddDays(7);
                end = end.AddDays(7);
            }

            return Json(events.ToArray());
        }
        [HttpPost("add-event")]
        public IActionResult AddEvent(Calendar calendar)
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login", "Employee");
            }

            if (ModelState.IsValid)
            {
                Calendar cal = new Calendar
                {
                    CalendarId = calendar.CalendarId,
                    Title = calendar.Title,
                    Start = calendar.Start,
                    End = calendar.End,
                    EmployeeId = calendar.EmployeeId
                };
                _context.Calendars.Add(cal);
                _context.SaveChanges();
                return RedirectToAction("Calendar");
            }
            return View("Calendar");
        }
    }
}