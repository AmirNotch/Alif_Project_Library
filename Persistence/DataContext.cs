using Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
       // Database.Migrate();
    }
    public DbSet<CardEvent> CardEvents { get; set; }

    // protected override void OnModelCreating(ModelBuilder builder)
    // {
    //     //base.OnModelCreating(builder);
    // }
}