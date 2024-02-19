using DataAccess.Interfaces;
using Entity.Models.User;

namespace Business.Repositories.Abstract;
public interface IUserRepository : IRepository<UserEntity>
{
    public UserEntity GetByUsername(string username);
    public UserEntity GetById(int userId);
    
}
