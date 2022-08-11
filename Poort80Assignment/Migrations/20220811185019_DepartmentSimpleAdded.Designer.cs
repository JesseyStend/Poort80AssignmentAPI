﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Poort80Assignment.Context;

#nullable disable

namespace Poort80Assignment.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20220811185019_DepartmentSimpleAdded")]
    partial class DepartmentSimpleAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Poort80Assignment.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Development department",
                            Name = "Development"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Inplan department",
                            Name = "Inplan"
                        });
                });

            modelBuilder.Entity("Poort80Assignment.Models.Employee", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            Name = "Jessey Stend"
                        },
                        new
                        {
                            Id = 2,
                            DepartmentId = 1,
                            Name = "Dennis Jongbloed"
                        },
                        new
                        {
                            Id = 3,
                            DepartmentId = 2,
                            Name = "Sary t'Lam"
                        });
                });

            modelBuilder.Entity("Poort80Assignment.Models.Employee", b =>
                {
                    b.HasOne("Poort80Assignment.Models.Department", null)
                        .WithMany("employees")
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("Poort80Assignment.Models.Department", b =>
                {
                    b.Navigation("employees");
                });
#pragma warning restore 612, 618
        }
    }
}
