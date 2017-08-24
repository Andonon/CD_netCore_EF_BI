using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using brightideas.Models;
using System.Linq;

namespace brightideas.Controllers
{
    public class LoginController : Controller
    {
        //==================================================================================
        // DB Connection settings. 
        //==================================================================================
        
        private usersContext _context; 

        public LoginController(usersContext context)
        {
            _context = context;
        }

        //==================================================================================
        // Root Route. Checks for session data and goes to Dashboard if found.
        //==================================================================================

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId != null)
            {
                return RedirectToAction("Main", "Idea");
            }
            else
            {
                return View();
            }
        }

        //==================================================================================
        // Register New User Route
        //==================================================================================

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                users ExistingUser = _context.users.SingleOrDefault(users => users.Email == model.Email);
                    if(ExistingUser != null)
                    {
                        // Console.WriteLine("Found User exists");
                        ViewBag.Message = "User with this email already exists! Please login.";
                        return View("Index", model);
                    };

                users NewUser = new users
                {
                    Name = model.Name,
                    Alias = model.Alias,
                    Email = model.Email,
                    Password = model.Password,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
                _context.Add(NewUser);
                _context.SaveChanges();
                NewUser = _context.users.SingleOrDefault(users => users.Email == NewUser.Email);
                HttpContext.Session.SetInt32("UserId", NewUser.Id);
                HttpContext.Session.SetString("UserAlias", NewUser.Alias);
                ViewBag.CurrUserAlias = HttpContext.Session.GetString(NewUser.Alias);
                return RedirectToAction("Main", "Idea");
            }
            else{
                return View("Index", model);
            }
        }

        //==================================================================================
        // Login Existing User Route
        //==================================================================================

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string loginemail, string loginpassword)
        {
            users FoundUser = _context.users.SingleOrDefault(users => users.Email == loginemail && users.Password == loginpassword);
            if (FoundUser == null)
            {
                ViewBag.Message = "Login failed.";
                return View("Index");
            }
            else
            {
                HttpContext.Session.SetInt32("UserId", FoundUser.Id);
                HttpContext.Session.SetString("UserAlias", FoundUser.Alias);
                return RedirectToAction("Main", "Idea");
            }
        }

        //==================================================================================
        // Logout Route
        //==================================================================================

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
