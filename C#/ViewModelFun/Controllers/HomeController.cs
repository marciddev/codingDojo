using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            Person newUser = new Person() {
                FirstName = "Test",
                LastName = "Last"
            };
            return View(newUser);
        }
        [HttpGet("/int")]
        public IActionResult IntArr() {
            int[] arr = new int[] {1,2,3,4,5};
            return View(arr);
        }
        [HttpGet("/string")]
        public IActionResult stringMethod() {
            string main = "Hello";
            return View("string", main);
        }
        [HttpGet("/users")]
        public IActionResult allUsers() {
            List<Person> persons = new List<Person>();
            Person person1 = new Person() {
                FirstName = "person1 first",
                LastName = "person1 last"
            };
            Person person2 = new Person() {
                FirstName = "person2 first",
                LastName = "person2 last"
            };
            persons.Add(person1);
            persons.Add(person2);
            return View(persons);
        }
    }
}
