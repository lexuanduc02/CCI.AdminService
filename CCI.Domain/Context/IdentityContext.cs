using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CCI.Domain;

public class IdentityContext : DbContext
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().ToTable("Users").HasKey(x => x.Id);
    }

    public DbConnection GetDbConnect()
    {
        return base.Database.GetDbConnection();
    }

    public new DbSet<TEntity> Set<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>();
    }

    public DbSet<User> Users { get; set; }
}
