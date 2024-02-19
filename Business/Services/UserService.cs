using Business.Interfaces;
using Entity.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services;
public class UserService : IUserService
{
    public bool CreateUser(UserEntity entity)
    {
        throw new NotImplementedException();
    }

    public bool DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public ICollection<UserEntity> GetUsers()
    {
        throw new NotImplementedException();
    }

    public bool UpdateUser(UserEntity entity)
    {
        throw new NotImplementedException();
    }
}

