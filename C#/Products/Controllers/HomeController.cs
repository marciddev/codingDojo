using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Microsoft.EntityFrameworkCore;

namespace Products.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context) {
            dbContext = context;
        }
        [HttpGet("/")]
        public IActionResult Index()
        {

            return View();
        }
        [HttpGet("categories")]
        public IActionResult Categories() {
            ViewBag.allCategories = dbContext.Categories
            .Include(category => category.CategoryProducts)
            .ThenInclude(associ => associ.Product);
            return View();
        }
        [HttpPost("categories/new")]
        public IActionResult newCat(Category c) {
            dbContext.Categories.Add(c);
            dbContext.SaveChanges();
            return Redirect($"/categories/{c.CategoryId}");
        }
        [HttpGet("categories/{id}")]
        public IActionResult ViewCat(int id) {
            var category = dbContext.Categories
            .Include(cat => cat.CategoryProducts)
            .ThenInclude(ass => ass.Product)
            .FirstOrDefault(cat => cat.CategoryId == id);
            ViewBag.profile = category;
            ViewBag.Products = dbContext.Products.ToList();
            return View();
        }
        [HttpPost("categories/{id}/add-product")]
        public IActionResult AddProductToCat(int id, int pro) {
            dbContext.Associations.Add(new Association {CategoryId = id, ProductId = pro});
            dbContext.SaveChanges();
            return Redirect($"/categories/{id}");
        }
        [HttpGet("products")]
        public IActionResult Products() {
            ViewBag.allProducts = dbContext.Products
            .Include(product => product.ProductCategories)
            .ThenInclude(association => association.Category);
            return View();
        }
        [HttpPost("products/new")]
        public IActionResult NewProduct(Product p) {
            dbContext.Products.Add(p);
            dbContext.SaveChanges();
            return Redirect($"/products/{p.ProductId}");
        }
        [HttpGet("products/{id}")]
        public IActionResult ProductProfile(int id) {
            ViewBag.Profile = dbContext.Products
            .Include(product => product.ProductCategories)
            .ThenInclude(association => association.Category)
            .FirstOrDefault(product => product.ProductId == id);
            ViewBag.Categories = dbContext.Categories.ToList();
            return View();
        }
        [HttpPost("/products/{id}/add-category")]
        public IActionResult AddCategory(int id, int cat) {
            Association a = new Association();
            a.CategoryId = cat;
            a.ProductId = id;
            dbContext.SaveChanges();
            dbContext.Associations.Add(a);
            dbContext.SaveChanges();
            return Redirect($"/products/{a.ProductId}");
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
