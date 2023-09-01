using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.BusinessCore.Entities;

namespace LMS.SqlServer.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(g => g.GroupId);

            builder.Property(g => g.EAN)
                .HasMaxLength(10) // Adjust the length as needed
                .IsRequired();

            builder.HasOne(g => g.Customer)
                .WithMany(c => c.Groups)
                .HasForeignKey(g => g.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
