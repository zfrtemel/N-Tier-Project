using Business.Interfaces;
using Business.Request;
using Business.Services;
using Core.Enum;
using Core.Web.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("admin/user"), Authorize(Roles = nameof(EUserRole.ADMIN))]
    public class UserController : APIControllerBase
    {
        private readonly ICustomerService _customerService;
        public UserController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return ApiResult("fetchedCustomers", true, _customerService.GetCustomers());
        }
        [HttpPost]
        public IActionResult AddCustomer([FromBody] CreateUserRequest request)
        {
            return ApiResult("addedCustomer", true, _customerService.CreateCustomer(request));
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] UpdateUserRequest request)
        {
            return ApiResult("updatedCustomer", true, _customerService.UpdateCustomer(id, request));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            return ApiResult("deletedCustomer", true, _customerService.DeleteCustomer(id));
        }
    }
}
