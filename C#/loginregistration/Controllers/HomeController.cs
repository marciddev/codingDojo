using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using loginregistration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace loginregistration.Controllers
{
    public class HomeController : Controller
    {
        private Context myContext;
        public HomeController(Context context) {
            myContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("register-user")]
        public IActionResult Register (User user) {
            if(ModelState.IsValid) {
                if(myContext.Users.Any(a => a.Email == user.Email)) {
                    ModelState.AddModelError("Email", "Email already exists...");
                    return View("Index");
                } else {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    user.Password = Hasher.HashPassword(user, user.Password);
                    myContext.SaveChanges();
                    myContext.Users.Add(user);
                    myContext.SaveChanges();
                    HttpContext.Session.SetInt32("logged_user", user.UserId);
                    return RedirectToAction("Success");
                }
                
            } else {
                return View("Index");
            }
        }
        [HttpGet("success")]
        public IActionResult Success() {
            if(HttpContext.Session.GetInt32("logged_user") != null) {
            int? id = HttpContext.Session.GetInt32("logged_user");
            int new_id = (int)id;
            User logged = myContext.Users.FirstOrDefault(u => u.UserId == new_id);
            ViewBag.login = logged;
                return View();
            } else {
                ModelState.AddModelError("Email", "You are not logged in!");
                return View("Index");
            }
        }
        [HttpGet("clear")]
        public IActionResult Clear() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        [HttpGet("login")]
        public IActionResult Login() {
            return View();
        }
        [HttpPost("login-user")]
        public IActionResult LoginUser(LoginUser logged) {
            var userInDb = myContext.Users.FirstOrDefault(u => u.Email == logged.Email);
            if(userInDb == null) {
                ModelState.AddModelError("Email", "Invalid email/password!");
                return View("Login");
            }
            var hasher = new PasswordHasher<LoginUser>();
            var result = hasher.VerifyHashedPassword(logged, userInDb.Password, logged.Password);
            if(result == 0) {
                ModelState.AddModelError("Password", "Invalid Email/Password");
                return View("Login");
            }
            HttpContext.Session.SetInt32("logged_user", userInDb.UserId);
            return RedirectToAction("Success");

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
