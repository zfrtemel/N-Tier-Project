using Business.Interfaces;
using Core.Enum;
using Core.Web.Abstracts;
using Core.Web.Abstracts.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Auth
{
    [Route("admin/auth")]
    public class AdminAuthController : APIControllerBase
    {
        private readonly IAuthService _authService;
        public AdminAuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Login as A Admin User response JWT Token as string
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthLoginRequest request)
        {
            return ApiResult("Welcome to the API", true, _authService.Login(request, EUserRole.ADMIN));
        }
    }
}
