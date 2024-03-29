using System.Collections.Generic;
using System.Linq;
using Intra.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intra.Controllers
{
    public class TodoController : Controller
    {
        private readonly DataContext _context;

        public TodoController(DataContext context)
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
        [HttpGet("todos")]
        public IActionResult Todos()
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login", "Employee");
            }

            ViewBag.Todos = _context.Todos.ToList();
            ViewBag.TheUser = ActiveUser;
            return View();
        }

        [HttpGet("todos/{id}")]
        public IActionResult TheTodo(int id)
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login", "Employee");
            }

            ViewBag.TheUser = ActiveUser;
            ViewBag.Todo = _context.Todos.Where(t => t.TodoId == id).SingleOrDefault();
            return View();
        }

        [HttpGet("edit-todo-page")]
        public IActionResult EditTodoPage()
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login", "Employee");
            }

            ViewBag.TheUser = ActiveUser;
            return View();
        }

        [HttpPost("todos/{id}/edit-todo-page/edit")]
        public IActionResult EditTodo(int id, int employee, string title, string description)
        {
            if (ModelState.IsValid)
            {
                Todo todo = _context.Todos.Where(t => t.TodoId == id).SingleOrDefault();
                todo.EmployeeId = employee;
                todo.TodoTitle = title;
                todo.TodoDescription = description;
                _context.SaveChanges();
                ViewBag.success = "Your todo has been updated";
                return RedirectToAction("Todos");
            }
            ViewBag.errors = "Todo was not updated";
            return RedirectToAction("Todos");
        }

        [HttpPost("add-todo")]
        public IActionResult AddTodo(Todo todo)
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login", "Employee");
            }
            if (ModelState.IsValid)
            {
                Todo newTodo = new Todo
                {
                    EmployeeId = todo.EmployeeId,
                    TodoId = todo.TodoId,
                    TodoTitle = todo.TodoTitle,
                    TodoDescription = todo.TodoDescription
                };
                _context.Todos.Add(newTodo);
                _context.SaveChanges();
                return RedirectToAction("Todos");
            }
            ViewBag.errors = "Todo was not added";
            return View("AddTodoPage");
        }

        [HttpGet("add-todo-page")]
        public IActionResult AddTodoPage()
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login", "Employee");
            }

            ViewBag.TheUser = ActiveUser;
            List<Employee> employees = _context.Employees.ToList();
            ViewBag.AllNames = employees;
            return View();
        }

        [HttpGet("delete-todo/{id}")]
        public IActionResult DeleteTodo(int id)
        {
            Todo todo = _context.Todos.Where(t => t.TodoId == id).SingleOrDefault();
            _context.Todos.Remove(todo);
            _context.SaveChanges();
            ViewBag.success = "Your todo was deleted";
            return RedirectToAction("Todos");
        }
    }
}