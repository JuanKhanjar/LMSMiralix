using LMS.BusinessCore.Entities;
using LMS.SqlServer.Configurations;
using Microsoft.EntityFrameworkCore;
namespace LMS.SqlServer.Data
{
    public class LMSDbContext : DbContext
    {
        // Define DbSet properties for your entities
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupProduct> GroupProducts { get; set; }
        public DbSet<PurchasedProduct> PurchasedProducts { get; set; }

        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new PurchasedProductConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new GroupProductConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }

}
