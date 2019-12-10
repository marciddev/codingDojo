using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wall.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wall.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context) {
            dbContext = context;
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
        [HttpGet("dashboard")]
        public IActionResult Dash() {
            if(HttpContext.Session.GetInt32("logged_user") == null) {
                return RedirectToAction("Index");
            }
            List<Message> messages = dbContext.Messages.Include(u => u.User).Include(m => m.Comments).ThenInclude(u => u.User).OrderByDescending(m => m.CreatedAt).ToList();

            return View(messages);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("post-message")]
        public IActionResult PostMsg(string message) {
            dbContext.Messages.Add(new Message {
                message = message,
                User = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("logged_user"))
            });
            dbContext.SaveChanges();
            return RedirectToAction("Dash");
        }
        [HttpPost("post-comment/{id}")]
        public IActionResult PostComment(int id, String CommentText) {
            dbContext.Comments.Add(new Comment {
                MessageId = id,
                UserId = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("logged_user")).UserId,
                CommentText = CommentText
            });
            dbContext.SaveChanges();
            return RedirectToAction("Dash");
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
