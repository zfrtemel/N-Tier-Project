using Core.Web.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class HomeController : APIControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return ApiResult("Welcome to the API", true, true);
        }
    }
}