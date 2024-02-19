using DataAccess.Interfaces;
using Entity.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.Abstract;
public interface IUserRepository : IRepository<UserEntity>
{
    public UserEntity GetByUsername(string username);
    public UserEntity GetById(int userId);
    
}
