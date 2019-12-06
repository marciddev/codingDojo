using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using chefsanddishes.Models;
using Microsoft.EntityFrameworkCore;

namespace chefsanddishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dContext;
        public HomeController(MyContext context) {
            dContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dContext.Chefs.Include(chef => chef.CreatedDishes).ToList();
            ViewBag.Chefs = AllChefs;
            return View();
        }
        [HttpGet("add-chef")]
        public IActionResult AddChef() {
            return View();
        }
        [HttpPost("create-chef")]
        public IActionResult CreateChef(Chef chef) {
            dContext.Chefs.Add(chef);
            dContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("dishes")]
        public IActionResult Dishes() {
            List<Dish> allDishes = dContext.Dishes.Include(dish => dish.Creator).ToList();
            ViewBag.AllDishes = allDishes;
            return View();
        }
        [HttpGet("add-dish")]
        public IActionResult AddDish() {
            @ViewBag.Chefs = dContext.Chefs.ToList();
            return View();
        }
        [HttpPost("create-dish")]
        public IActionResult CreateDish(Dish d, int ChefId) {
            d.ChefId = ChefId;
            dContext.Dishes.Add(d);
            dContext.SaveChanges();
            return RedirectToAction("Dishes");
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