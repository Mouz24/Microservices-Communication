﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product.Entities;

#nullable disable

namespace Product.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Product.Entities.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = new Guid("beb87d73-cd7f-4d5a-ad5e-8a1f3014758a"),
                            Name = "Tomatoe",
                            Price = 123.00m
                        },
                        new
                        {
                            Id = new Guid("7cef8783-a410-4c22-8f32-87495b31ffd3"),
                            Name = "Potatoe",
                            Price = 100.00m
                        },
                        new
                        {
                            Id = new Guid("9ebeb342-80b4-47c4-8343-07c9ff63d60a"),
                            Name = "Sausage",
                            Price = 250.00m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
