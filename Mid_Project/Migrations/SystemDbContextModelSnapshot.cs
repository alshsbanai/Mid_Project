﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mid_Project.Data;

#nullable disable

namespace Mid_Project.Migrations
{
    [DbContext(typeof(SystemDbContext))]
    partial class SystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Mid_Project.Models.Admin", b =>
                {
                    b.Property<int>("admin_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("admin_Id"), 1L, 1);

                    b.Property<string>("full_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("admin_Id");

                    b.HasIndex("username")
                        .IsUnique();

                    b.ToTable("admin");
                });

            modelBuilder.Entity("Mid_Project.Models.Buss", b =>
                {
                    b.Property<int>("bus_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bus_Id"), 1L, 1);

                    b.Property<int>("AdminID")
                        .HasColumnType("int");

                    b.Property<string>("captin_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("number_of_seats")
                        .HasColumnType("int");

                    b.HasKey("bus_Id");

                    b.HasIndex("AdminID");

                    b.ToTable("buss");
                });

            modelBuilder.Entity("Mid_Project.Models.Passenger", b =>
                {
                    b.Property<int>("pass_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("pass_Id"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phone")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("pass_Id");

                    b.HasIndex("email")
                        .IsUnique();

                    b.HasIndex("username")
                        .IsUnique();

                    b.ToTable("passenger");
                });

            modelBuilder.Entity("Mid_Project.Models.Trip", b =>
                {
                    b.Property<int>("trip_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("trip_Id"), 1L, 1);

                    b.Property<int>("AdminID")
                        .HasColumnType("int");

                    b.Property<int>("bus_Number")
                        .HasColumnType("int");

                    b.Property<string>("destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("end_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("start_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("trip_Id");

                    b.HasIndex("AdminID");

                    b.ToTable("trip");
                });

            modelBuilder.Entity("Mid_Project.Models.Trip_Buss", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("BussID")
                        .HasColumnType("int");

                    b.Property<int>("TripID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BussID");

                    b.HasIndex("TripID");

                    b.ToTable("trip_buss");
                });

            modelBuilder.Entity("Mid_Project.Models.Trip_Passenger", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("PassengerID")
                        .HasColumnType("int");

                    b.Property<int>("TripID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PassengerID");

                    b.HasIndex("TripID");

                    b.ToTable("trip_passenger");
                });

            modelBuilder.Entity("Mid_Project.Models.Buss", b =>
                {
                    b.HasOne("Mid_Project.Models.Admin", "admin")
                        .WithMany("buss")
                        .HasForeignKey("AdminID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("admin");
                });

            modelBuilder.Entity("Mid_Project.Models.Trip", b =>
                {
                    b.HasOne("Mid_Project.Models.Admin", "Admin")
                        .WithMany("trip")
                        .HasForeignKey("AdminID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Mid_Project.Models.Trip_Buss", b =>
                {
                    b.HasOne("Mid_Project.Models.Buss", "buss")
                        .WithMany("trip_buss")
                        .HasForeignKey("BussID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mid_Project.Models.Trip", "trip")
                        .WithMany("trip_buss")
                        .HasForeignKey("TripID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("buss");

                    b.Navigation("trip");
                });

            modelBuilder.Entity("Mid_Project.Models.Trip_Passenger", b =>
                {
                    b.HasOne("Mid_Project.Models.Passenger", "passenger")
                        .WithMany("trip_passenger")
                        .HasForeignKey("PassengerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mid_Project.Models.Trip", "trip")
                        .WithMany("trip_passenger")
                        .HasForeignKey("TripID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("passenger");

                    b.Navigation("trip");
                });

            modelBuilder.Entity("Mid_Project.Models.Admin", b =>
                {
                    b.Navigation("buss");

                    b.Navigation("trip");
                });

            modelBuilder.Entity("Mid_Project.Models.Buss", b =>
                {
                    b.Navigation("trip_buss");
                });

            modelBuilder.Entity("Mid_Project.Models.Passenger", b =>
                {
                    b.Navigation("trip_passenger");
                });

            modelBuilder.Entity("Mid_Project.Models.Trip", b =>
                {
                    b.Navigation("trip_buss");

                    b.Navigation("trip_passenger");
                });
#pragma warning restore 612, 618
        }
    }
}
