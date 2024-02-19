using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Core.Interfaces;
using DataAccess.Context;
using DataAccess.Interfaces;
using System.Data;

namespace DataAccess.Implements;

public class UnitOfWork : IUnitOfWork
{
    private MainDbContext _context;

    public UnitOfWork(MainDbContext context)
    {
        _context = context;
    }

    public ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot)
    {
        return new DatabaseTransaction(_context.Database.BeginTransaction(isolationLevel));
    }

    public void Add<T>(T obj) where T : class
    {
        var set = _context.Set<T>();
        set.Add(obj);
    }

    public void Add<T>(params T[] obj) where T : class
    {
        var set = _context.Set<T>();
        set.AddRange(obj);
    }

    public void Update<T>(T obj) where T : class
    {
        var set = _context.Set<T>();
        set.Attach(obj);
        _context.Entry(obj).State = EntityState.Modified;
    }

    public EntityEntry<T> Remove<T>(T obj) where T : class
    {
        var set = _context.Set<T>();
        return set.Remove(obj);
    }

    public void Remove<T>(params T[] obj) where T : class
    {
        var set = _context.Set<T>();
        set.RemoveRange(obj);
    }

    public DbSet<T> Set<T>() where T : class
    {
        return _context.Set<T>();
    }

    public IQueryable<T> Query<T>() where T : class
    {
        return Set<T>();
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public EntityEntry<T> Attach<T>(T newUser) where T : class
    {
        var set = _context.Set<T>();
        return set.Attach(newUser);
    }

    public void Dispose()
    {
        //_context.Dispose();
        _context = null;
    }

    public void Remove<T>(IQueryable<T> obj) where T : class
    {
        Remove(obj.ToArray());
    }

    public void Remove<T>(IEnumerable<T> obj) where T : class
    {
        Remove(obj.ToArray());
    }
}
