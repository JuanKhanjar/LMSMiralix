﻿using LMS.BusinessCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.SqlServer.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Configure the entity properties and keys
            builder.HasKey(c => c.CustomerId);

            // Define the one-to-many relationship between Customer and PurchasedProduct
            builder.HasMany(c => c.PurchasedProducts)
                   .WithOne(pp => pp.Customer)
                   .HasForeignKey(pp => pp.CustomerId);

            // Define the one-to-many relationship between Customer and Group
            builder.HasMany(c => c.Groups)
                   .WithOne(g => g.Customer)
                   .HasForeignKey(g => g.CustomerId);

            // Seed data (you can add more customers as needed)
            builder.HasData(
                new Customer { CustomerId = 1, CustomerName = "Vejle Kommune" ,Email="vejle@gmail.com",PhoneNumber="429292929"},
                new Customer { CustomerId = 2, CustomerName = "Herning Kommune",Email = "herning@gmail.com",PhoneNumber = "429292930" }
            // Add more customer records here
            );
        }
    }
}
