using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Core.Interfaces;
using System.Data;

namespace DataAccess.Interfaces;

public interface IUnitOfWork
{
    ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot);
    void Commit();
    Task CommitAsync();
    void Add<T>(T obj) where T : class;
    void Add<T>(params T[] obj) where T : class;
    EntityEntry<T> Remove<T>(T obj) where T : class;
    void Remove<T>(params T[] obj) where T : class;
    void Remove<T>(IQueryable<T> obj) where T : class;
    void Remove<T>(IEnumerable<T> obj) where T : class;
    void Update<T>(T obj) where T : class;
    DbSet<T> Set<T>() where T : class;
    IQueryable<T> Query<T>() where T : class;
    EntityEntry<T> Attach<T>(T obj) where T : class;
}
