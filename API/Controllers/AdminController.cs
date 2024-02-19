using Business.Interfaces;
using Business.Request;
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
        [HttpPost]
        public IActionResult AddAdmin([FromBody] CreateUserRequest request)
        {
            return ApiResult("addedAdmin", true, _adminService.CreateAdmin(request));
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAdmin(int id, [FromBody] UpdateUserRequest request)
        {
            return ApiResult("updatedAdmin", true, _adminService.UpdateAdmin(id, request));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAdmin(int id)
        {
            return ApiResult("deletedAdmin", true, _adminService.DeleteAdmin(id));
        }
    }
}
