﻿// <auto-generated />
using System;
using CoreViewBar.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreViewBar.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220216210954_CoreViewBar-DB")]
    partial class CoreViewBarDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreViewBar.Models.Coupon4Discount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Coupon4Discounts");
                });

            modelBuilder.Entity("CoreViewBar.Models.DiscountShopBag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Coupon4DiscountID")
                        .HasColumnType("int");

                    b.Property<string>("ShopBagGUID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShopBagID")
                        .HasColumnType("int");

                    b.Property<bool>("isDiscountApplied")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("Coupon4DiscountID");

                    b.HasIndex("ShopBagID")
                        .IsUnique();

                    b.ToTable("DiscountShopBags");
                });

            modelBuilder.Entity("CoreViewBar.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("DateTimeOrder")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ShopBagID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CoreViewBar.Models.OrderItem", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountApplied")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FinalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductID", "OrderID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("CoreViewBar.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CoreViewBar.Models.ShopBag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<int?>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("ShopBagID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("ShopBags");
                });

            modelBuilder.Entity("CoreViewBar.Models.DiscountShopBag", b =>
                {
                    b.HasOne("CoreViewBar.Models.Coupon4Discount", "Coupon4Discount")
                        .WithMany()
                        .HasForeignKey("Coupon4DiscountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreViewBar.Models.ShopBag", "ShopBag")
                        .WithOne("DiscountShopBags")
                        .HasForeignKey("CoreViewBar.Models.DiscountShopBag", "ShopBagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coupon4Discount");

                    b.Navigation("ShopBag");
                });

            modelBuilder.Entity("CoreViewBar.Models.OrderItem", b =>
                {
                    b.HasOne("CoreViewBar.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreViewBar.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CoreViewBar.Models.ShopBag", b =>
                {
                    b.HasOne("CoreViewBar.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID");

                    b.HasOne("CoreViewBar.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CoreViewBar.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("CoreViewBar.Models.Product", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("CoreViewBar.Models.ShopBag", b =>
                {
                    b.Navigation("DiscountShopBags");
                });
#pragma warning restore 612, 618
        }
    }
}
