﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Data;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(RentCarsDbContext))]
    [Migration("20230329152011_AddressFix")]
    partial class AddressFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetWithNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Domain.Entities.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarsModelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fuel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlaceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarsModelId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Domain.Entities.CarAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CarAttributes");
                });

            modelBuilder.Entity("Domain.Entities.CarsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CarsModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandName = "AUDI",
                            ModelName = "A1"
                        },
                        new
                        {
                            Id = 2,
                            BrandName = "AUDI",
                            ModelName = "A3"
                        },
                        new
                        {
                            Id = 3,
                            BrandName = "AUDI",
                            ModelName = "A4"
                        },
                        new
                        {
                            Id = 4,
                            BrandName = "AUDI",
                            ModelName = "A5"
                        },
                        new
                        {
                            Id = 5,
                            BrandName = "AUDI",
                            ModelName = "A6"
                        },
                        new
                        {
                            Id = 6,
                            BrandName = "AUDI",
                            ModelName = "A7"
                        },
                        new
                        {
                            Id = 7,
                            BrandName = "AUDI",
                            ModelName = "A8"
                        },
                        new
                        {
                            Id = 8,
                            BrandName = "AUDI",
                            ModelName = "E-TRON"
                        },
                        new
                        {
                            Id = 9,
                            BrandName = "AUDI",
                            ModelName = "Q2"
                        },
                        new
                        {
                            Id = 10,
                            BrandName = "AUDI",
                            ModelName = "Q3"
                        },
                        new
                        {
                            Id = 11,
                            BrandName = "AUDI",
                            ModelName = "Q4"
                        },
                        new
                        {
                            Id = 12,
                            BrandName = "AUDI",
                            ModelName = "Q5"
                        },
                        new
                        {
                            Id = 13,
                            BrandName = "AUDI",
                            ModelName = "Q7"
                        },
                        new
                        {
                            Id = 14,
                            BrandName = "AUDI",
                            ModelName = "Q8"
                        },
                        new
                        {
                            Id = 15,
                            BrandName = "AUDI",
                            ModelName = "TT"
                        },
                        new
                        {
                            Id = 16,
                            BrandName = "AUDI",
                            ModelName = "R8"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PricePerHour")
                        .HasColumnType("decimal(19,4)");

                    b.Property<decimal>("PricePreDay")
                        .HasColumnType("decimal(19,4)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CarId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("Domain.Entities.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserAppId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserAppId");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("Domain.Entities.RentPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(19,4)");

                    b.Property<int>("RentId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RentId")
                        .IsUnique();

                    b.ToTable("RentsPayments");
                });

            modelBuilder.Entity("Domain.Entities.User2Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserAppId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserAppId");

                    b.ToTable("Users2Addresses");
                });

            modelBuilder.Entity("Domain.Entities.UserApp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UsersApp");
                });

            modelBuilder.Entity("Domain.Entities.UserEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserAppId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserAppId")
                        .IsUnique()
                        .HasFilter("[UserAppId] IS NOT NULL");

                    b.ToTable("UsersEmployees");
                });

            modelBuilder.Entity("Domain.Entities.UserEmployee2Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserEmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("UserEmployeeId");

                    b.ToTable("UserEmployees2Branches");
                });

            modelBuilder.Entity("Domain.Entities.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("PESEL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserAppId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserAppId")
                        .IsUnique()
                        .HasFilter("[UserAppId] IS NOT NULL");

                    b.ToTable("UsersInfo");
                });

            modelBuilder.Entity("Domain.Entities.Branch", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany("Branches")
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.HasOne("Domain.Entities.CarsModel", "CarsModel")
                        .WithMany("Cars")
                        .HasForeignKey("CarsModelId");

                    b.Navigation("CarsModel");
                });

            modelBuilder.Entity("Domain.Entities.CarAttribute", b =>
                {
                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithMany("CarAttributes")
                        .HasForeignKey("CarId");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Domain.Entities.Offer", b =>
                {
                    b.HasOne("Domain.Entities.Branch", "Branch")
                        .WithMany("Offers")
                        .HasForeignKey("BranchId");

                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithMany("Offers")
                        .HasForeignKey("CarId");

                    b.Navigation("Branch");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Domain.Entities.Rent", b =>
                {
                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithMany("Rents")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserApp", "UserApp")
                        .WithMany("Rents")
                        .HasForeignKey("UserAppId");

                    b.Navigation("Car");

                    b.Navigation("UserApp");
                });

            modelBuilder.Entity("Domain.Entities.RentPayment", b =>
                {
                    b.HasOne("Domain.Entities.Rent", "Rent")
                        .WithOne("RentPayment")
                        .HasForeignKey("Domain.Entities.RentPayment", "RentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rent");
                });

            modelBuilder.Entity("Domain.Entities.User2Address", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany("User2Addresses")
                        .HasForeignKey("AddressId");

                    b.HasOne("Domain.Entities.UserApp", "UserApp")
                        .WithMany("User2Addresses")
                        .HasForeignKey("UserAppId");

                    b.Navigation("Address");

                    b.Navigation("UserApp");
                });

            modelBuilder.Entity("Domain.Entities.UserEmployee", b =>
                {
                    b.HasOne("Domain.Entities.UserApp", "UserApp")
                        .WithOne("UserEmployee")
                        .HasForeignKey("Domain.Entities.UserEmployee", "UserAppId");

                    b.Navigation("UserApp");
                });

            modelBuilder.Entity("Domain.Entities.UserEmployee2Branch", b =>
                {
                    b.HasOne("Domain.Entities.Branch", "Branch")
                        .WithMany("UserEmployee2Branches")
                        .HasForeignKey("BranchId");

                    b.HasOne("Domain.Entities.UserEmployee", "UserEmployee")
                        .WithMany("UserEmployee2Branches")
                        .HasForeignKey("UserEmployeeId");

                    b.Navigation("Branch");

                    b.Navigation("UserEmployee");
                });

            modelBuilder.Entity("Domain.Entities.UserInfo", b =>
                {
                    b.HasOne("Domain.Entities.UserApp", "UserApp")
                        .WithOne("UserInfo")
                        .HasForeignKey("Domain.Entities.UserInfo", "UserAppId");

                    b.Navigation("UserApp");
                });

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Navigation("Branches");

                    b.Navigation("User2Addresses");
                });

            modelBuilder.Entity("Domain.Entities.Branch", b =>
                {
                    b.Navigation("Offers");

                    b.Navigation("UserEmployee2Branches");
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.Navigation("CarAttributes");

                    b.Navigation("Offers");

                    b.Navigation("Rents");
                });

            modelBuilder.Entity("Domain.Entities.CarsModel", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Domain.Entities.Rent", b =>
                {
                    b.Navigation("RentPayment");
                });

            modelBuilder.Entity("Domain.Entities.UserApp", b =>
                {
                    b.Navigation("Rents");

                    b.Navigation("User2Addresses");

                    b.Navigation("UserEmployee");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("Domain.Entities.UserEmployee", b =>
                {
                    b.Navigation("UserEmployee2Branches");
                });
#pragma warning restore 612, 618
        }
    }
}
