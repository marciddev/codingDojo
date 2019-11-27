using System;
using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey {
    public class HomeController : Controller {
        [HttpGet("")]
        public IActionResult index() {
            return View();
        }
        [HttpPost("submit")]
        public IActionResult results(string name, string location, string language, string comment) {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            return View();
        }
    }
}