using Business.Interfaces;
using Entity.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services;

public class AdminService : IAdminService
{
    public bool CreateAdmin(UserEntity entity)
    {
        throw new NotImplementedException();
    }

    public bool DeleteAdmin(int id)
    {
        throw new NotImplementedException();
    }

    public ICollection<UserEntity> GetAdmins()
    {
        throw new NotImplementedException();
    }

    public bool UpdateAdmin(UserEntity entity)
    {
        throw new NotImplementedException();
    }
}

