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
    public class GroupProductConfiguration : IEntityTypeConfiguration<GroupProduct>
    {
        public void Configure(EntityTypeBuilder<GroupProduct> builder)
        {
            builder.HasKey(gp => gp.GroupProductId);

            builder.HasOne(gp => gp.Group)
                .WithMany(g => g.GroupProducts)
                .HasForeignKey(gp => gp.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(gp => gp.Product)
                .WithMany(p => p.GroupProducts)
                .HasForeignKey(gp => gp.PurchasedProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
