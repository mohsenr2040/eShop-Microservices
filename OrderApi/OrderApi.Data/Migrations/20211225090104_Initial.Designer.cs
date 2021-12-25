﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderApi.Data.Context;

namespace OrderApi.Data.Migrations
{
    [DbContext(typeof(OrderContext))]
    [Migration("20211225090104_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Version", "1.0")
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("OrderApi.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Addrress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CustomerGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderState")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrderApi.Domain.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("OrderApi.Domain.Entities.OrderDetail", b =>
                {
                    b.HasOne("OrderApi.Domain.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
