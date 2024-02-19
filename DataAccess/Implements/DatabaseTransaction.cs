using Microsoft.EntityFrameworkCore.Storage;
using Core.Interfaces;

namespace DataAccess.Implements;

public class DatabaseTransaction : ITransaction
{
    private readonly IDbContextTransaction _transaction;

    public DatabaseTransaction(IDbContextTransaction transaction)
    {
        _transaction = transaction;
    }

    public void Commit()
    {
        _transaction.Commit();
    }

    public void Rollback()
    {
        _transaction.Rollback();
    }

    public void Dispose()
    {
        _transaction.Dispose();
    }
}
