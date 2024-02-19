using Core.Interfaces.Models;
using Entity.Models.Ticket;
using Entity.Models.User;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;
public class MainDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<TicketEntity> Tickets { get; set; }
    public DbSet<TicketOperationLogEntity> TicketOperationLogs { get; set; }


    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasMany(x => x.Tickets).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        modelBuilder.Entity<TicketEntity>().HasMany(x => x.TicketOperationLogs).WithOne(x => x.Ticket).HasForeignKey(x => x.TicketId);

    }

    private void HandleTimeStamps()
    {
        ChangeTracker.Entries().Where(x => typeof(ISoftDelete).IsAssignableFrom(x.Entity.GetType())).All((entry) =>
        {
            //if (!typeof(ISoftDelete).IsAssignableFrom(entry.Entity.GetType())) return false;

            switch (entry.State)
            {
                case EntityState.Modified:
                    if (entry.Properties.Any(x => x.Metadata.Name == "UpdatedAt"))
                        entry.CurrentValues["UpdatedAt"] = DateTime.Now.ToUniversalTime();
                    break;
                case EntityState.Deleted:
                    bool CanBypassSoftDelete = false;
                    var SoftDeleteProperty = entry.Entity.GetType().GetProperties().FirstOrDefault(x => x.Name == "BypassSoftDelete");

                    if (SoftDeleteProperty != null)
                        CanBypassSoftDelete = Convert.ToBoolean(SoftDeleteProperty.GetValue(entry.Entity));

                    if (entry.Properties.Any(x => x.Metadata.Name == "DeletedAt") && !CanBypassSoftDelete)
                    {
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["DeletedAt"] = DateTime.Now.ToUniversalTime();
                    }
                    break;
                default: break;
            }

            return true;
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        HandleTimeStamps();

        return base.SaveChangesAsync(cancellationToken);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        HandleTimeStamps();

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        HandleTimeStamps();

        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override int SaveChanges()
    {
        HandleTimeStamps();

        return base.SaveChanges();
    }

}
