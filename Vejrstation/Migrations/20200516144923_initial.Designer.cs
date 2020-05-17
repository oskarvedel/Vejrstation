﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vejrstation.Data;

namespace Vejrstation.Migrations
{
    [DbContext(typeof(WeatherServerDbContext))]
    [Migration("20200516144923_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.3.20181.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vejrstation.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1001,
                            PasswordHash = "asdfasdf12341234",
                            UserName = "Flydende vejrstation 999"
                        },
                        new
                        {
                            Id = 1002,
                            PasswordHash = "$2b$10$CVhr0CGf2jgOGzAGBW1QkuGoyD9zHEFfuMJ9PcgKVdfHmEozy.7g6",
                            UserName = "John_1954"
                        },
                        new
                        {
                            Id = 1003,
                            PasswordHash = "$2b$10$qlb0TxXk9jPbWwTMBS1lYOWdl34xwtxPEQ9NDYtyKjH0EqQzTJSB.",
                            UserName = "Jesper Theilgaard"
                        },
                        new
                        {
                            Id = 1004,
                            PasswordHash = "$2b$10$CnmGJqhTvRb3plF.KemOPudF29hlXi2kwcnZ37Ao1nK0vChBM94CG",
                            UserName = "Peter Qvortrup Geisling"
                        },
                        new
                        {
                            Id = 1005,
                            PasswordHash = "$2b$10$hI.1VnFnpO.TMQwfjerBBeh3VER0QbphRGKVAGtU9Bril7PE5AYbm",
                            UserName = "Dr. Pjuskibusk"
                        });
                });

            modelBuilder.Entity("Vejrstation.Entities.WeatherObservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Humidity_Percentage")
                        .HasColumnType("int");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Pressure_Millibar")
                        .HasColumnType("float");

                    b.Property<double>("TemperatureCelsius")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("WeatherObservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Humidity_Percentage = 2,
                            Latitude = 101010101.0,
                            Longitude = 2222222.0,
                            Name = "Kolding",
                            Pressure_Millibar = 3.0,
                            TemperatureCelsius = 1.0
                        },
                        new
                        {
                            Id = 1002,
                            Date = new DateTime(2020, 5, 3, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Humidity_Percentage = 10,
                            Latitude = 23.45224,
                            Longitude = 19.353000000000002,
                            Name = "Bunden af bubbers badekar",
                            Pressure_Millibar = 9.1999999999999993,
                            TemperatureCelsius = 33.100000000000001
                        },
                        new
                        {
                            Id = 1003,
                            Date = new DateTime(2020, 2, 3, 1, 50, 0, 0, DateTimeKind.Unspecified),
                            Humidity_Percentage = 10,
                            Latitude = 12.46733,
                            Longitude = 2.2351999999999999,
                            Name = "Himmelbjerget",
                            Pressure_Millibar = 9.1999999999999993,
                            TemperatureCelsius = 33.100000000000001
                        },
                        new
                        {
                            Id = 1004,
                            Date = new DateTime(2020, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Humidity_Percentage = 10,
                            Latitude = 56.158149999999999,
                            Longitude = 10.21203,
                            Name = "Hjemme paa gaarden",
                            Pressure_Millibar = 9.1999999999999993,
                            TemperatureCelsius = 33.100000000000001
                        },
                        new
                        {
                            Id = 1005,
                            Date = new DateTime(2020, 11, 15, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Humidity_Percentage = 100,
                            Latitude = 69.420000000000002,
                            Longitude = 69.420000000000002,
                            Name = "Atlantis",
                            Pressure_Millibar = 9000.2000000000007,
                            TemperatureCelsius = 20.100000000000001
                        },
                        new
                        {
                            Id = 1006,
                            Date = new DateTime(2020, 11, 15, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            Humidity_Percentage = 50,
                            Latitude = 12.432399999999999,
                            Longitude = 54.123399999999997,
                            Name = "Anna Lises Bar",
                            Pressure_Millibar = 900.0,
                            TemperatureCelsius = 25.100000000000001
                        });
                });
#pragma warning restore 612, 618
        }
    }
}