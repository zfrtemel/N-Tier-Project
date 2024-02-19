using Core.Web.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Auth
{
    [Route("auth")]
    public class UserAuthController : APIControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login()
        {
            return ApiResult("Welcome to the API", true, true);
        }
    }
}
