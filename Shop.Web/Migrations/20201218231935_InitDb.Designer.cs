﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Web.Data;

namespace Shop.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201218231935_InitDb")]
    partial class InitDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shop.Web.Data.Entidades.Produtos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsAvailable");

                    b.Property<DateTime?>("LastPurchase");

                    b.Property<DateTime?>("LastSale");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Price");

                    b.Property<double>("Stock");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}