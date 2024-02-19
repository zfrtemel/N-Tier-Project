using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace DataAccess.Interfaces;

public interface IRepository<T> where T : class
{
    IEnumerable<T> All();
    IQueryable<T> Get();
    T? Get(int id);
    EntityEntry<T> Add(T entity);
    void Add(params T[] entities);
    EntityEntry<T> Update(T entity);
    int Delete();
    EntityEntry<T> Delete(T entity);
    void Delete(IQueryable<T> entities);
    void Delete(IEnumerable<T> entities);
    void Delete(params T[] entities);
    IQueryable<T> Find(Expression<Func<T, bool>> exp);
}
