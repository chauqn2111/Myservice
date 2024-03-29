﻿// <auto-generated />
using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessObjects.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20231010035948_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessObjects.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categorys");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Beverages"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Condiment"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Confection"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Dairi Products"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Grains/Gereals"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Meal/Poultry"
                        },
                        new
                        {
                            CategoryId = 7,
                            CategoryName = "Produce"
                        },
                        new
                        {
                            CategoryId = 8,
                            CategoryName = "Seafood"
                        },
                        new
                        {
                            CategoryId = 9,
                            CategoryName = "Bedfood"
                        });
                });

            modelBuilder.Entity("BusinessObjects.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            ProductName = "Quang Le",
                            UnitPrice = 67333000m,
                            UnitsInStock = 20
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2,
                            ProductName = "Bao An",
                            UnitPrice = 223230m,
                            UnitsInStock = 20
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3,
                            ProductName = "Truong Vinh",
                            UnitPrice = 42333m,
                            UnitsInStock = 456
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 4,
                            ProductName = "Hoa Khanh",
                            UnitPrice = 543322m,
                            UnitsInStock = 300
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 5,
                            ProductName = "Le Thien",
                            UnitPrice = 3215556m,
                            UnitsInStock = 250
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 6,
                            ProductName = "Bao Quoc",
                            UnitPrice = 1500000m,
                            UnitsInStock = 15
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 7,
                            ProductName = "Truong Phi",
                            UnitPrice = 222222m,
                            UnitsInStock = 1
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 8,
                            ProductName = "QuanVu",
                            UnitPrice = 12345m,
                            UnitsInStock = 1
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 9,
                            ProductName = "Luu Bi",
                            UnitPrice = 54321m,
                            UnitsInStock = 1
                        });
                });

            modelBuilder.Entity("BusinessObjects.Product", b =>
                {
                    b.HasOne("BusinessObjects.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BusinessObjects.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
