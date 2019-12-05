using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext Dbcontext;
        public HomeController(MyContext context) {
            Dbcontext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            // List<User> allUsers = Dbcontext.Users.ToList();
            // foreach(User u in allUsers) {
            //     Console.WriteLine(u.FirstName);
            // }
            List<Dish> allDishes = Dbcontext.Dishes.ToList();
            IEnumerable<Dish> allDish = Dbcontext.Dishes.OrderByDescending(d => d.CreatedAt);
            @ViewBag.all = allDish;
            return View();
        }
        [HttpGet("create")]
        public IActionResult createForm() {
            return View();
        }
        // [HttpGet("create")]
        // public IActionResult CreateUser() {
        //     User u = new User { FirstName = "Kevin", LastName="Cox", Email="kevin.kvc34@gmail.com", Password="helloworld123"};
        //     Dbcontext.Users.Add(u);
        //     Dbcontext.SaveChanges();
        //     Console.WriteLine(u);
        //     return RedirectToAction("Index");
        // }
        [HttpPost("/create-dish")]
        public IActionResult createDish(Dish dish) {
            if(ModelState.IsValid) {
                Dbcontext.Dishes.Add(dish);
                Dbcontext.SaveChanges();
                return Redirect("/");
            } else {
                return View("createForm");
            }
        }
        [HttpGet("{id}")]
        public IActionResult viewDish(int id) {
            ViewBag.Profile = Dbcontext.Dishes.FirstOrDefault(d => d.DishId == id);
            return View();
        }
        [HttpGet("delete/{id}")]
        public IActionResult deleteDish(int id) {
            Dish retrieved = Dbcontext.Dishes.FirstOrDefault(d => d.DishId == id);
            Dbcontext.Dishes.Remove(retrieved);
            Dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("edit/{id}")]
        public IActionResult editDish(int id) {
            Dish retrieved = Dbcontext.Dishes.FirstOrDefault(d => d.DishId == id);
            ViewBag.Profile = retrieved;
            return View();
        }
        [HttpPost("edit-dish/{id}")]
        public IActionResult editDishPost(Dish d, int id) {
            Dish retrieved = Dbcontext.Dishes.FirstOrDefault(di => di.DishId == id);
            retrieved.Chef = d.Chef;
            retrieved.Name = d.Name;
            retrieved.Description = d.Description;
            retrieved.Tastiness = d.Tastiness;
            retrieved.Calories = d.Calories;
            retrieved.UpdatedAt = DateTime.Now;
            Dbcontext.SaveChanges();
            return RedirectToAction("Index");
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
