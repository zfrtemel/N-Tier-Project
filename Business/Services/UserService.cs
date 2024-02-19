using Business.Interfaces;
using Business.Repositories.Abstract;
using Core.Enum;
using Core.Exceptions;
using DataAccess.Interfaces;
using Entity.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public bool CreateUser(UserEntity entity)
    {
        throw new NotImplementedException();
    }

    public bool DeleteUser(int id)
    {
        var user = _userRepository.Get().FirstOrDefault(x => x.Id == id);
        if (user == null) throw new BaseException("NotFound");
        _unitOfWork.Remove(user);
        _unitOfWork.Commit();
        return true;
    }

    public IQueryable<UserEntity> Get(int[] ids)
    {
        return _userRepository.Get().Where(x => ids.Contains(x.Id));
    }

    public UserEntity Get(int id)
    {
        return _userRepository.Get().FirstOrDefault(x => x.Id == id) ?? throw new BaseException("NotFound");
    }

    public IQueryable<UserEntity> Get()
    {
        return _userRepository.Get();
    }

    public IQueryable<UserEntity> Get(Expression<Func<UserEntity, bool>> expression)
    {
        return _userRepository.Find(expression);
    }

    public UserEntity GetOne(Expression<Func<UserEntity, bool>> expression)
    {
        var user = _userRepository.Find(expression).FirstOrDefault();
        if (user == null) throw new BaseException("NotFound");
        return user;
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

