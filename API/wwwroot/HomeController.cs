using Microsoft.AspNetCore.Mvc;

namespace API.wwwroot
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
