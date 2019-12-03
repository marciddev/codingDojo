using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("quotes")]
        public IActionResult PostQuotes(string name, string quote) {
            string query = $"INSERT INTO users (name, quote, createdat) VALUES ('{name}', '{quote}', NOW())";
            DbConnector.Execute(query);
            return Redirect("quotes");
        }
        [HttpGet("quotes")]
        public IActionResult GetQuotes() {
            List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM users ORDER BY createdat DESC");
            // To provide this data, we could use ViewBag or a View Model.  ViewBag shown here:
            ViewBag.Users = AllUsers;
            return View();
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
