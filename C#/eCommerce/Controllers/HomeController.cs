using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context) {
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
        [HttpGet("logout")]
        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        [HttpPost("login-user")]
        public IActionResult Login(LoginUser u) {
            if(dbContext.Users.Any(user => user.Email == u.LoginEmail)) {
                User logged = dbContext.Users.FirstOrDefault(email => email.Email == u.LoginEmail);
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(u, logged.Password, u.LoginPassword);
                if(result == 0) {
                    ModelState.AddModelError("LoginPassword", "Password was incorrect!");
                    return View("Index");
                } else {
                    HttpContext.Session.SetInt32("logged_user", logged.UserId);
                    return RedirectToAction("Dash");
                }
            } else {
                ModelState.AddModelError("LoginEmail", "Email was not found!");
                return View("Index");
            }
        }
        [HttpGet("dashboard")]
        public IActionResult Dash() {
            if(HttpContext.Session.GetInt32("logged_user") == null) {
                return RedirectToAction("Index");
            }
            List<Product> allProducts = dbContext.Products.Take(5).ToList();
            List<User> allUsers = dbContext.Users.OrderByDescending(d => d.CreatedAt).Take(3).ToList();
            List<Transaction> allTransactions = dbContext.Transactions.Include(u => u.User).Include(u=> u.Product).OrderByDescending(de => de.CreatedAt).Take(3).ToList();
            DashModel all = new DashModel {
                users = allUsers,
                products = allProducts,
                transactions = allTransactions
            };
            return View(all);
        }
        [HttpGet("orders")]
        public IActionResult Orders() {
            List<Transaction> allOrders = dbContext.Transactions.OrderByDescending(m => m.CreatedAt).ToList();
            List<User> allUsers = dbContext.Users.ToList();
            List<Product> allProducts = dbContext.Products.ToList();
            DashModel dash = new DashModel {
                users = allUsers,
                products = allProducts,
                transactions = allOrders
            };
            return View(dash);
        }
        [HttpGet("customers")]
        public IActionResult Customers() {
            List<User> users = dbContext.Users.ToList();
            return View(users);
        }
        [HttpGet("delete-user/{id}")]
        public IActionResult delete(int id) {
            if(dbContext.Users.Any(u => u.UserId == id)) {
                dbContext.Users.Remove(dbContext.Users.FirstOrDefault(u => u.UserId == id));
                dbContext.SaveChanges();
                return RedirectToAction("Customers");
            } else {
                return RedirectToAction("Customers");
            }
        }
        [HttpPost("create-user")]
        public IActionResult createUser(string customerName) {
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            User newuser = new User {
                FirstName = customerName,
                LastName = "(Admin Created)",
                Email = $"{customerName}@admin.org",
                Password = customerName
            };
            newuser.Password = hasher.HashPassword(newuser, newuser.Password);
            dbContext.SaveChanges();
            dbContext.Users.Add(newuser);
            dbContext.SaveChanges();
            return Redirect("/customers");
        }
        [HttpPost("create-order")]
        public IActionResult createOrder(int UserId, int ProductId, int Amount) {
            dbContext.Transactions.Add(new Transaction {
                Amount = Amount,
                UserId = UserId,
                ProductId = ProductId
            });
            Product p = dbContext.Products.FirstOrDefault(pro => pro.ProductId == ProductId);
            p.Quantity -= Amount;
            dbContext.SaveChanges();
            dbContext.SaveChanges();
            return Redirect("/orders");
        }
        [HttpGet("products")]
        public IActionResult Products() {
            List<Product> allProds = dbContext.Products.OrderByDescending(d => d.CreatedAt).ToList();
            return View(allProds);
        }
        [HttpPost("register-product")]
        public IActionResult RegisterProd(String whatever1, int whatever2) {
            Product p = new Product {
                Name = whatever1,
                Quantity = whatever2
            };
            dbContext.Products.Add(p);
            dbContext.SaveChanges();
            return Redirect("/products");
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
