﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231015165457_SumQuantity")]
    partial class SumQuantity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityLayer.Concrete.AdminUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastloginIP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("AdminUser");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            LastLoginDate = new DateTime(2023, 10, 15, 19, 54, 57, 475, DateTimeKind.Local).AddTicks(1090),
                            LastloginIP = "",
                            NameSurname = "Emin Susam",
                            Password = "202cb962ac59075b964b07152d234b70",
                            UserName = "Emin123"
                        });
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ikon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Message", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .HasMaxLength(80)
                        .HasColumnType("Varchar(80)");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("Messages")
                        .HasMaxLength(500)
                        .HasColumnType("Varchar(500)");

                    b.Property<DateTime>("RecDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .HasMaxLength(100)
                        .HasColumnType("Varchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .HasMaxLength(150)
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("District")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("MailAdress")
                        .HasMaxLength(80)
                        .HasColumnType("Varchar(80)");

                    b.Property<string>("NameSurname")
                        .HasMaxLength(100)
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("OrderNumber")
                        .HasMaxLength(20)
                        .HasColumnType("Varchar(20)");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<int>("PaymentOption")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("Varchar(20)");

                    b.Property<DateTime>("RecDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ShippedFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(10)
                        .HasColumnType("Varchar(10)");

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EntityLayer.Concrete.OrderDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasMaxLength(100)
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("ProductPicture")
                        .HasMaxLength(150)
                        .HasColumnType("Varchar(150)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<string>("CargoDetail")
                        .HasColumnType("Varchar(150)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Detail")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Star")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("SumQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("Varchar(150)");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("EntityLayer.Concrete.OrderDetail", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Order", "Order")
                        .WithMany("OrderDetail")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Product", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Category", "category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Order", b =>
                {
                    b.Navigation("OrderDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
