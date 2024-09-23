using CCI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace CCI.Domain
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().ToTable("Department").HasKey(x => x.Id);
        }

        public DbConnection GetDbConnect()
        {
            return base.Database.GetDbConnection();
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<UserDepartment> UserDepartment { get; set; }
        public DbSet<JobPost> JobPost { get; set; }
        public DbSet<Requirement> Requirement { get; set; }
        public DbSet<RequirementType> RequirementType { get; set; }
    }
}
