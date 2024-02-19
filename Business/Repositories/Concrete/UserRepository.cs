using Business.Repositories.Abstract;
using DataAccess.Context;
using DataAccess.Implements;
using Entity.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Business.Repositories.Concrete;
public class UserRepository : Repository<UserEntity>, IUserRepository
{
    private readonly MainDbContext _dbContext;
    public UserRepository(MainDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public UserEntity? GetByUsername(string username)
    {
        return _dbContext.Users.Where(x => x.Username == username).FirstOrDefault();
    }

    public UserEntity? GetById(int userId)
    {
        return _dbContext.Users.FirstOrDefault(x => x.Id == userId);
    }
}
