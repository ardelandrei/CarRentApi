﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201015132112_RenameDateOfManufacture")]
    partial class RenameDateOfManufacture
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Models.ManufacturerDetails", b =>
                {
                    b.Property<int>("ManufacturerDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfManufacture")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(17)")
                        .HasMaxLength(17);

                    b.HasKey("ManufacturerDetailsId");

                    b.HasAlternateKey("VIN");

                    b.ToTable("ManufacturerDetails");
                });

            modelBuilder.Entity("DataAccess.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanBeRented")
                        .HasColumnType("bit");

                    b.Property<int>("ManufacturerDetailsId")
                        .HasColumnType("int");

                    b.Property<decimal>("RentPricePerHour")
                        .HasColumnType("decimal(10, 3)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerDetailsId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("DataAccess.Models.Vehicle", b =>
                {
                    b.HasOne("DataAccess.Models.ManufacturerDetails", "ManufacturerDetails")
                        .WithMany()
                        .HasForeignKey("ManufacturerDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
