using LMS.BusinessCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.SqlServer.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Define the primary key
            builder.HasKey(c => c.CustomerId);

            // Define other property configurations (if needed)

            // Seed data
            builder.HasData(
                new Customer { CustomerId = 1, CustomerName = "Vejle Kommone" },
                new Customer { CustomerId = 2, CustomerName = "Vejen Kommone" }
            );

            // Define relationships
            builder.HasMany(c => c.PurchasedProduct)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Groups)
                .WithOne(g => g.Customer)
                .HasForeignKey(g => g.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
