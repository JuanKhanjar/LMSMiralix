﻿// <auto-generated />
using System;
using LMS.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LMS.SqlServer.Migrations
{
    [DbContext(typeof(LMSDbContext))]
    [Migration("20231016052847_Emailsfields")]
    partial class Emailsfields
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LMS.BusinessCore.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CustomerName = "Vejle Kommune",
                            Email = "vejle@gmail.com",
                            PhoneNumber = "429292929",
                            RegistrationDate = new DateTime(2023, 10, 16, 7, 28, 47, 695, DateTimeKind.Local).AddTicks(671)
                        },
                        new
                        {
                            CustomerId = 2,
                            CustomerName = "Herning Kommune",
                            Email = "herning@gmail.com",
                            PhoneNumber = "429292930",
                            RegistrationDate = new DateTime(2023, 10, 16, 7, 28, 47, 695, DateTimeKind.Local).AddTicks(719)
                        });
                });

            modelBuilder.Entity("LMS.BusinessCore.Entities.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("EAN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            CustomerId = 1,
                            EAN = "ABC123",
                            GroupName = "Group 1"
                        },
                        new
                        {
                            GroupId = 2,
                            CustomerId = 2,
                            EAN = "XYZ456",
                            GroupName = "Group 2"
                        });
                });

            modelBuilder.Entity("LMS.BusinessCore.Entities.GroupProduct", b =>
                {
                    b.Property<int>("GroupProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupProductId"));

                    b.Property<int>("AddedQuantity")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("PurchasedProductId")
                        .HasColumnType("int");

                    b.HasKey("GroupProductId");

                    b.HasIndex("GroupId");

                    b.HasIndex("PurchasedProductId");

                    b.ToTable("GroupProducts");

                    b.HasData(
                        new
                        {
                            GroupProductId = 1,
                            AddedQuantity = 5,
                            GroupId = 1,
                            PurchasedProductId = 1
                        },
                        new
                        {
                            GroupProductId = 2,
                            AddedQuantity = 3,
                            GroupId = 2,
                            PurchasedProductId = 2
                        });
                });

            modelBuilder.Entity("LMS.BusinessCore.Entities.PurchasedProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("PurchasedQty")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CustomerId");

                    b.ToTable("PurchasedProducts");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CustomerId = 1,
                            ProductName = "Product A",
                            ProductPrice = 10.99m,
                            PurchasedQty = 2
                        },
                        new
                        {
                            ProductId = 2,
                            CustomerId = 2,
                            ProductName = "Product B",
                            ProductPrice = 19.99m,
                            PurchasedQty = 4
                        });
                });

            modelBuilder.Entity("LMS.BusinessCore.Entities.Group", b =>
                {
                    b.HasOne("LMS.BusinessCore.Entities.Customer", "Customer")
                        .WithMany("Groups")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("LMS.BusinessCore.Entities.GroupProduct", b =>
                {
                    b.HasOne("LMS.BusinessCore.Entities.Group", "Group")
                        .WithMany("GroupProducts")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LMS.BusinessCore.Entities.PurchasedProduct", "PurchasedProduct")
                        .WithMany()
                        .HasForeignKey("PurchasedProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("PurchasedProduct");
                });

            modelBuilder.Entity("LMS.BusinessCore.Entities.PurchasedProduct", b =>
                {
                    b.HasOne("LMS.BusinessCore.Entities.Customer", "Customer")
                        .WithMany("PurchasedProducts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("LMS.BusinessCore.Entities.Customer", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("PurchasedProducts");
                });

            modelBuilder.Entity("LMS.BusinessCore.Entities.Group", b =>
                {
                    b.Navigation("GroupProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
