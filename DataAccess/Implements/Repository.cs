using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using DataAccess.Interfaces;
using System.Linq.Expressions;

namespace DataAccess.Implements;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _set;

    public Repository(DbContext dbContext)
    {
        _context = dbContext;
        _set = _context.Set<T>();
    }

    /// <summary>
    /// Adds given entity in database
    /// </summary>
    /// <param name="entity">Entity that is going to be added</param>
    /// <returns type="EntityEntry<T>">Entity entry object for watching changes</returns>
    public EntityEntry<T> Add(T entity)
    {
        return _set.Add(entity);
    }

    /// <summary>
    /// Adds multiple entities to the database
    /// </summary>
    /// <param name="entities">Entities to add</param>
    /// <returns></returns>
    public void Add(params T[] entities)
    {
        _set.AddRange(entities);
    }

    /// <summary>
    /// Updates given entity in database
    /// </summary>
    /// <returns type="IEnumerable<T>">Entity entry object for watching changes</returns>
    public IEnumerable<T> All()
    {
        return _set.ToList();
    }

    /// <summary>
    /// Retrieves entity from database
    /// </summary>
    /// <param name="id">ID of Entity</param>
    /// <returns type="T">Returns found entity</returns>
    public T? Get(int id)
    {
        return _set.Find(id);
    }

    /// <summary>
    /// Updates given entity in database
    /// </summary>
    /// <param name="entity">Entity that is going to be updated</param>
    /// <returns type="EntityEntry<T>">Entity entry object for watching changes</returns>
    public EntityEntry<T> Update(T entity)
    {
        return _set.Update(entity);
    }

    /// <summary>
    /// Deletes given entity from database
    /// </summary>
    /// <param name="entity">Entity that is going to be deleted</param>
    /// <returns type="EntityEntry<T>">Entity entry object for watching changes</returns>
    public EntityEntry<T> Delete(T entity)
    {
        return _set.Remove(entity);
    }

    /// <summary>
    /// Deletes all of the content of db set
    /// </summary>
    /// <returns>Deleted entity count</returns>
    public int Delete()
    {
        return _set.ExecuteDelete();//.RemoveRange(_set.ToList());
    }

    /// <summary>
    /// Finds entities that matches filter
    /// </summary>
    /// <param name="exp">Find expression</param>
    /// <returns type="IQueryable<T>">Returns entity data set that matches</returns>
    public IQueryable<T> Find(Expression<Func<T, bool>> exp)
    {
        return _set.Where(exp);
    }

    /// <summary>
    /// Returns all of the entities
    /// </summary>
    /// <returns type="IQueryable<T>">Entity Data</returns>
    public IQueryable<T> Get()
    {
        return _set;
    }

    /// <summary>
    /// Deletes given entities from database
    /// </summary>
    /// <param name="entities">Entity list to be deleted</param>
    /// <returns></returns>
    public void Delete(params T[] entities)
    {
        _set.RemoveRange(entities);
    }

    /// <summary>
    /// Deletes given entities from database
    /// </summary>
    /// <param name="entities">Entity list to be deleted</param>
    /// <returns></returns>
    public void Delete(IQueryable<T> entities)
    {
        Delete(entities.ToArray());
    }

    /// <summary>
    /// Deletes given entities from database
    /// </summary>
    /// <param name="entities">Entity list to be deleted</param>
    /// <returns></returns>
    public void Delete(IEnumerable<T> entities)
    {
        Delete(entities.ToArray());
    }
}
