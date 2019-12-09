using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context){ 
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("register-user")]
        public IActionResult Register(User user) {
            if(ModelState.IsValid) {
                if(dbContext.Users.Any(u => u.Email == user.Email)) {
                    ModelState.AddModelError("Email", "This email already exists !");
                    return View("Index");
                }
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                user.Password = hasher.HashPassword(user, user.Password);
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("logged_user", user.UserId);
                return RedirectToAction("Dash");
            } else {
                return View("Index");
            }
        }
        [HttpGet("dashboard")]
        public IActionResult Dash() {
            if(HttpContext.Session.GetInt32("logged_user") == null) {
                return View("Index");
            }
            List<Wedding> weddings = dbContext.Weddings.Include(wed => wed.Attendants)
            .ThenInclude(arrange => arrange.User).ToList();
            ViewBag.log = dbContext.Users.FirstOrDefault(us => us.UserId == HttpContext.Session.GetInt32("logged_user"));
            return View(weddings);
        }
        [HttpGet("logout")]
        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        [HttpPost("login-user")]
        public IActionResult Login(LoginUser u) {
            if(dbContext.Users.Any(user => user.Email == u.Email)) {
                User logged = dbContext.Users.FirstOrDefault(email => email.Email == u.Email);
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(u, logged.Password, u.Password);
                if(result == 0) {
                    ModelState.AddModelError("Password", "Password was incorrect!");
                    return View("Index");
                } else {
                    HttpContext.Session.SetInt32("logged_user", logged.UserId);
                    return RedirectToAction("Dash");
                }
            } else {
                ModelState.AddModelError("Email", "Email was not found!");
                return View("Index");
            }
        }
        [HttpGet("wedding/new")]
        public IActionResult newWed() {
            return View();
        }
        [HttpPost("create-wedding")]
        public IActionResult CreateWedding(Wedding wedding) {
            if(ModelState.IsValid) {
                var result = DateTime.Compare(DateTime.Now, wedding.DateOf);
                if(result < 0) {
                    dbContext.Weddings.Add(wedding);
                    dbContext.SaveChanges();
                    return Redirect($"/weddings/{wedding.WeddingId}");
                } else {
                    ModelState.AddModelError("DateOf", "The date was invalid.");
                    return View("newWed");
                }
            } else {
                return View("newWed");
            }
        }
        [HttpGet("weddings/{id}")]
        public IActionResult viewWed(int id) {
            Wedding wed = dbContext.Weddings
            .Include(w => w.Attendants)
            .ThenInclude(atten => atten.User)
            .FirstOrDefault(w => w.WeddingId == id);
            ViewBag.wedding = wed;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
