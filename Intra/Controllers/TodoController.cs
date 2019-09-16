using System.Linq;
using Intra.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Intra.Controllers
{
    public class TodoController : Controller
    {
        private readonly DataContext _context;

        public TodoController(DataContext context)
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
        [HttpGet("todos")]
        public IActionResult Todos()
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login", "User");
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
                return RedirectToAction("Login", "User");
            }

            ViewBag.TheUser = ActiveUser;
            ViewBag.Todo = _context.Todos.Where(t => t.TodoId == id).SingleOrDefault();
            return View();
        }

        [HttpPost("add-todo")]
        public IActionResult AddTodo(Todo todo)
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login", "User");
            }
            if (ModelState.IsValid)
            {
                Todo newTodo = new Todo
                {
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
        
    }
}