using Business.Request;
using Entity.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces;
public interface IAdminService
{
    public bool CreateAdmin(CreateUserRequest request);
    public bool UpdateAdmin(int id, UpdateUserRequest request);
    public bool DeleteAdmin(int id);
    public ICollection<UserEntity> GetAdmins();
}

