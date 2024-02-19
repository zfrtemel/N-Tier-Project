using Microsoft.EntityFrameworkCore;
using Core.Interfaces.Models;
using System.Linq.Expressions;

namespace DataAccess.Extensions;

internal static class SoftDeleteModelBuilderExtension
{
    public static ModelBuilder ApplySoftDeleteQueryFilter(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (!typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType) || entityType.BaseType != null)
            {
                continue;
            }

            var param = Expression.Parameter(entityType.ClrType, "entity");
            var prop = Expression.PropertyOrField(param, nameof(ISoftDelete.DeletedAt));

            entityType.SetQueryFilter(Expression.Lambda(Expression.Equal(prop, Expression.Constant(null)), param));
        }

        return modelBuilder;
    }
}
