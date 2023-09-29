using LMS.BusinessCore.Entities;
using LMS.SqlServer.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .ConfigureWarnings(warnings =>
                {
                    warnings.Throw(RelationalEventId.MultipleCollectionIncludeWarning); // Throw the exception
                    warnings.Ignore(RelationalEventId.MultipleCollectionIncludeWarning); // Or ignore the warning
                });
        }

    }

}
