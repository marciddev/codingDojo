using System;
using Microsoft.AspNetCore.Mvc;
namespace time {
    public class HomeController : Controller {
        [HttpGet("/")]
        public IActionResult index() {
            return View();
        }
    }
}