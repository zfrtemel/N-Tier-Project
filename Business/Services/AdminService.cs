using Business.Interfaces;
using Business.Request;
using Core.Enum;
using Core.Exceptions;
using Entity.Models.User;
using Mapster;

namespace Business.Services;

public class AdminService : IAdminService
{
    private readonly IUserService _userService;
    public AdminService(IUserService userService)
    {
        _userService = userService;
    }
    public bool CreateAdmin(CreateUserRequest request)
    {
        var entity = request.Adapt<UserEntity>();
        entity.Role = nameof(EUserRole.ADMIN);
        _userService.CreateUser(entity);
        return true;
    }

    public bool DeleteAdmin(int id)
    {
        var adminUser = _userService.Get().Where(x => x.Id == id && x.Role == nameof(EUserRole.ADMIN));
        if (adminUser == null) throw new BaseException("NotFound");
        _userService.DeleteUser(id);
        return true;
    }

    public ICollection<UserEntity> GetAdmins()
    {
        return _userService.Get().Where(x => x.Role == nameof(EUserRole.ADMIN)).ToList();
    }

    public bool UpdateAdmin(int id, UpdateUserRequest request)
    {
        var adminUser = _userService.Get().Where(x => x.Id == id && x.Role == nameof(EUserRole.ADMIN)).FirstOrDefault();
        if (adminUser == null) throw new BaseException("NotFound");
        adminUser.Email = request.Email;
        adminUser.Username = request.Username;
        _userService.UpdateUser(adminUser);
        return true;
    }
}

