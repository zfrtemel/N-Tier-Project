using Business.Interfaces;
using Business.Request;
using Core.Enum;
using Core.Exceptions;
using Entity.Models.User;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services;
public class CustomerService : ICustomerService
{
    private readonly IUserService _userService;
    public CustomerService(IUserService userService)
    {
        _userService = userService;
    }
    public bool CreateCustomer(CreateUserRequest request)
    {
        var entity = request.Adapt<UserEntity>();
        entity.Role = nameof(EUserRole.CUSTOMER);
        _userService.CreateUser(entity);
        return true;
    }

    public bool DeleteCustomer(int id)
    {
        var adminUser = _userService.Get().Where(x => x.Id == id && x.Role == nameof(EUserRole.CUSTOMER));
        if (adminUser == null) throw new BaseException("NotFound");
        _userService.DeleteUser(id);
        return true;
    }

    public ICollection<UserEntity> GetCustomers()
    {
        return _userService.Get().Where(x => x.Role == nameof(EUserRole.CUSTOMER)).ToList();
    }

    public bool UpdateCustomer(int id, UpdateUserRequest request)
    {
        var adminUser = _userService.Get().Where(x => x.Id == id && x.Role == nameof(EUserRole.CUSTOMER)).FirstOrDefault();
        if (adminUser == null) throw new BaseException("NotFound");
        adminUser.Email = request.Email;
        adminUser.Username = request.Username;
        _userService.UpdateUser(adminUser);
        return true;

    }
}
