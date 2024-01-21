using Microsoft.EntityFrameworkCore;
using QueryOptimisation.Config;

namespace QueryOptimisation;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions opts)
        : base(opts)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonConfig());
    }
}
