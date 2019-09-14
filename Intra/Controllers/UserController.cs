using System.Linq;
using Intra.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace Intra.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
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
            User checkEmail = _context.Users.Where(u => u.Email == user.Email).SingleOrDefault();
            if (checkEmail != null)
            {
                ViewBag.errors = "This email already exists";
                return RedirectToAction("Register");
            }
            if (ModelState.IsValid)
            {
                PasswordHasher<UserViewModel.RegisterUser> hasher = new PasswordHasher<UserViewModel.RegisterUser>();
                User newUser = new User
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
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
            User checkEmail = _context.Users.Where(u => u.Email == user.Email).SingleOrDefault();
            if (checkEmail != null)
            {
                var hasher = new PasswordHasher<User>();
                if (0 != hasher.VerifyHashedPassword(checkEmail, checkEmail.Password, user.Password))
                {
                    HttpContext.Session.SetInt32("UserId", checkEmail.UserId);
                    HttpContext.Session.SetString("FirstName", checkEmail.FirstName);
                    HttpContext.Session.SetString("LastName", checkEmail.LastName);
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

        [HttpGet("users")]
        public IActionResult Users()
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login");
            }

            ViewBag.TheUser = ActiveUser;
            ViewBag.Users = _context.Users.ToList();
            return View();
        }
        
        [HttpGet("users/{id}")]
        public IActionResult Profile(int id)
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login");
            }

            ViewBag.TheUser = ActiveUser;
            ViewBag.User = _context.Users.Where(u => u.UserId == id).SingleOrDefault();
            return View();
        }

        [HttpGet("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (ActiveUser == null)
            {
                return RedirectToAction("Login");
            }

            User user = _context.Users.Where(u => u.UserId == id).SingleOrDefault();
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Dashboard", "Home");
        }

        [HttpGet("add-user-page")]
        public IActionResult AddUserPage()
        {
            return View();
        }

        [HttpPost("add-user")]
        public IActionResult AddUser()
        {
            if (ModelState.IsValid)
            {
                
            }

            return View("AddUserPage");
        }
    }
}