using Microsoft.AspNetCore.Mvc;
namespace TestProj {
    public class HomeController : Controller {
        [Route("")]
        [HttpGet]
        public string Index() {
            return "It works!";
        }
        [Route("workpls")]
        [HttpGet]
        public string workpls() {
            return "It works yet again!";
        }
        [HttpGet("hello/{user}")]
        public string user(string user) {
            return $"Hello, {user}";
        }
    }
}