using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.BusinessCore.Entities;
using LMS.SqlServer.Configurations;
using Microsoft.EntityFrameworkCore;
namespace LMS.SqlServer.Data
{
    public class LMSDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupProduct> GroupProducts { get; set; }

        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new GroupProductConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }

}
