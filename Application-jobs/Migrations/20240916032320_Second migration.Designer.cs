﻿// <auto-generated />
using System;
using Application_jobs.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Application_jobs.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240916032320_Second migration")]
    partial class Secondmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Application_jobs.Models.ApplicationJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("Interviews")
                        .HasColumnType("int");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("LastUpdateOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Recruter")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("SkillRequest")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<bool>("TecnicTest")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("StatusId");

                    b.ToTable("ApplicationJob", (string)null);
                });

            modelBuilder.Entity("Application_jobs.Models.ApplicationStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationStatus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "C01",
                            Description = "APPLIED"
                        },
                        new
                        {
                            Id = 2,
                            Code = "C02",
                            Description = "IN PROCESS"
                        },
                        new
                        {
                            Id = 3,
                            Code = "C03",
                            Description = "INTERVIEW"
                        },
                        new
                        {
                            Id = 4,
                            Code = "C04",
                            Description = "CLOSED"
                        });
                });

            modelBuilder.Entity("Application_jobs.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("Application_jobs.Models.ApplicationJob", b =>
                {
                    b.HasOne("Application_jobs.Models.Company", "CompanyRefence")
                        .WithMany("ApplicationReference")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application_jobs.Models.ApplicationStatus", "StatusRefence")
                        .WithMany("ApplicationReference")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyRefence");

                    b.Navigation("StatusRefence");
                });

            modelBuilder.Entity("Application_jobs.Models.ApplicationStatus", b =>
                {
                    b.Navigation("ApplicationReference");
                });

            modelBuilder.Entity("Application_jobs.Models.Company", b =>
                {
                    b.Navigation("ApplicationReference");
                });
#pragma warning restore 612, 618
        }
    }
}
