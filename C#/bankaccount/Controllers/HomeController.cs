using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bankaccount.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace bankaccount.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
     
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("create-user")]
        public IActionResult CreateUser(User u) {
            if(ModelState.IsValid) {
                User logged_user = dbContext.Users.FirstOrDefault(user => user.Email == u.Email);
                if(logged_user == null) {
                    PasswordHasher<User> hasher = new PasswordHasher<User>();
                    u.Password = hasher.HashPassword(u, u.Password);
                    u.Balance = 400;
                    dbContext.SaveChanges();
                    dbContext.Users.Add(u);
                    dbContext.SaveChanges();
                    HttpContext.Session.SetInt32("log", u.UserId);
                    return Redirect($"/transactions/account/{u.UserId}");
                } else {
                    ModelState.AddModelError("Email", "This Email already exists!");
                    return View("Index");
                }
            } else {
                return View("Index");
            }
        }
        [HttpGet("transactions/account/{id}")]
        public IActionResult Transactions(int id) {
            int? userid = HttpContext.Session.GetInt32("log");
            if(userid == null) {
                return RedirectToAction("Index");
            }
            int userid2 = (int)userid;
            ViewBag.User = dbContext.Users.Include(use => use.Transactions).FirstOrDefault(use => use.UserId == userid2);
            ViewBag.allTrans = dbContext.Transactions.Where(transaction => transaction.UserId == userid2).OrderByDescending(created => created.CreatedAt);

            return View();
        }
        [HttpGet("logout")]
        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        [HttpGet("login")]
        public IActionResult Login() {
            return View();
        }
        [HttpPost("login-user")]
        public IActionResult LoginUser(LoginUser Loginuser) {
            User u = dbContext.Users.FirstOrDefault(user => user.Email == Loginuser.Email);
            if(ModelState.IsValid) {
                if(u == null) {
                    ModelState.AddModelError("Email", "Email does not exist!");
                    return View("Login");
                } else {
                    var hasher = new PasswordHasher<LoginUser>();
                    var result = hasher.VerifyHashedPassword(Loginuser, u.Password, Loginuser.Password);
                    if(result == 0) {
                        ModelState.AddModelError("Password", "Password incorrect.");
                        return View("Login");
                    } else {
                        HttpContext.Session.SetInt32("log", u.UserId);
                        return Redirect($"/transactions/account/{u.UserId}");
                    }
                }
            } else {
                return View("Login");
            }
        }
        [HttpPost("/make-transaction")]
        public IActionResult MakeTrans(Transaction t) {
            User u = dbContext.Users.Include(user => user.Transactions).FirstOrDefault(user => user.UserId == (int)HttpContext.Session.GetInt32("log"));
            if(u.Balance - t.Amount < 0) {
                return Redirect($"/transactions/account/{u.UserId}");
            }
            t.CreatedAt = DateTime.Now;
            t.UserId = u.UserId;
            u.Balance -= t.Amount;
            dbContext.Transactions.Add(t);
            dbContext.SaveChanges();
            return Redirect($"transactions/account/{u.UserId}");
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
