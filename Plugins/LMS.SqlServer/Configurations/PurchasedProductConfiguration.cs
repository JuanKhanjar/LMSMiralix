using LMS.BusinessCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.SqlServer.Configurations
{
    public class PurchasedProductConfiguration : IEntityTypeConfiguration<PurchasedProduct>
    {
        public void Configure(EntityTypeBuilder<PurchasedProduct> builder)
        {
            // Configure the entity properties and keys
            builder.HasKey(pp => pp.ProductId);

            // Define the many-to-one relationship between PurchasedProduct and Customer
            builder.HasOne(pp => pp.Customer)
                   .WithMany(c => c.PurchasedProducts)
                   .HasForeignKey(pp => pp.CustomerId);

            // Configure a soft delete behavior by setting PurchasedQty to zero when deleted
            //builder.HasQueryFilter(pp => pp.PurchasedQty > 0);

            // Seed data for PurchasedProducts (you can add more)
            builder.HasData(
                new PurchasedProduct { ProductId = 1, ProductName = "Product A", ProductPrice = 10.99m, PurchasedQty = 2, CustomerId = 1 },
                new PurchasedProduct { ProductId = 2, ProductName = "Product B", ProductPrice = 19.99m, PurchasedQty = 4, CustomerId = 2 }
            // Add more purchased product records here
            );
        }
    }
}
