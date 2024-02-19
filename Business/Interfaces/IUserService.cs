using Entity.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces;

public interface IUserService
{
    public bool CreateUser(UserEntity entity);
    public bool UpdateUser(UserEntity entity);
    public bool DeleteUser(int id);
    public ICollection<UserEntity> GetUsers();
}

