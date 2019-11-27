using System;
using Microsoft.AspNetCore.Mvc;
namespace razorfun {
    public class HomeController : Controller {
        [HttpGet("/")]
        public IActionResult index() {
            return View();
        }
    }
}