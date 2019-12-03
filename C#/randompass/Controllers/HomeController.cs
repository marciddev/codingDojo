using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using randompass.Models;
using Microsoft.AspNetCore.Http;

namespace randompass.Controllers
{
    public class HomeController : Controller
    {
        public string generatePasscode(int i) {
            Random r = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            string s = "";
            for(int j=0;j<=i;j++) {
                s += chars[r.Next(0, chars.Length)];
            }
            return s;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("times") == null) {
                HttpContext.Session.SetInt32("times", 0);
            }

            ViewBag.Passcode = HttpContext.Session.GetString("passcode");
            ViewBag.Times = HttpContext.Session.GetInt32("times");

            return View();
            
        }
        [HttpGet("/genPass")]
        public IActionResult genPass() {
            Console.WriteLine(HttpContext.Session.GetInt32("times") + "*****");
            int? currCount = HttpContext.Session.GetInt32("times");
            currCount++;
            HttpContext.Session.SetInt32("times", (int)currCount);
            HttpContext.Session.SetString("passcode", generatePasscode(14));
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
