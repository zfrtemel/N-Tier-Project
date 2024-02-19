using Entity.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces;

public interface IUserService
{
    public bool CreateUser(UserEntity entity);
    public bool UpdateUser(UserEntity entity);
    public bool DeleteUser(int id);
    public ICollection<UserEntity> GetUsers();
    public IQueryable<UserEntity> Get(int[] ids);

    public UserEntity Get(int id);
    public IQueryable<UserEntity> Get();
    public UserEntity GetOne(Expression<Func<UserEntity, bool>> expression);
    public IQueryable<UserEntity> Get(Expression<Func<UserEntity, bool>> expression);


}

