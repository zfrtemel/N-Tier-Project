using Business.Interfaces;
using Core.Enum;
using Core.Web.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("admin"), Authorize(Roles = nameof(EUserRole.ADMIN))]
    public class AdminController : APIControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            return ApiResult("fetchedAdmins", true, _adminService.GetAdmins());
        }
    }
}
