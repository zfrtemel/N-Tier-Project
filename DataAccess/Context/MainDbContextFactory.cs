using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess.Contexts;

public class MainDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
{
    public MainDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MainDbContext>();
        // configurasyon dosyasından alınabilir reel proje olmadığı için bunu yapmadım
        optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=TicketApp; Integrated Security=True; Connect Timeout=30; Encrypt=False; Trust Server Certificate=False; Application Intent=ReadWrite; Multi Subnet Failover=False");

        return new MainDbContext(optionsBuilder.Options);
    }
}
