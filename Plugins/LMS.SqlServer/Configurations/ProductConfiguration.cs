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
    public class ProductConfiguration : IEntityTypeConfiguration<PurchasedProduct>
    {
        public void Configure(EntityTypeBuilder<PurchasedProduct> builder)
        {
            builder.HasKey(p => p.ProductId);

            builder.HasOne(p => p.Customer)
                .WithMany(c => c.PurchasedProduct)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
