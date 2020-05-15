using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Vejrstation.Entities;
using static BCrypt.Net.BCrypt;

namespace Vejrstation.Data
{
    public static class DbUtilities
    {
        public const int BcryptWorkfactor = 10;

        public static void SeedData(WeatherServerDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Accounts.Any())
                SeedAccounts(context);
            if (!context.WeatherObservations.Any())
                SeedWeatherObservations(context);
        }

        static void SeedAccounts(WeatherServerDbContext context)
        {
            context.Accounts.AddRange(
                // Seed manager
                new Account
                {
                    Id = 1,
                    UserName = "John_1954",
                    PasswordHash = HashPassword("mitPassword1", BcryptWorkfactor)
                },
                // Seed some models
                new Account
                {
                    Id = 2,
                    UserName = "Jesper Theilgaard",
                    PasswordHash = HashPassword("mitPassword2", BcryptWorkfactor)
                },
                new Account
                {
                    Id = 3,
                    UserName = "Peter Qvortrup Geisling",
                    PasswordHash = HashPassword("mitPassword3", BcryptWorkfactor)
                },
                new Account
                {
                    Id = 4,
                    UserName = "Dr. Pjuskibusk",
                    PasswordHash = HashPassword("mitPassword4", BcryptWorkfactor)
                }
            );
            context.SaveChanges();
        }

        private static void SeedWeatherObservations(WeatherServerDbContext context)
        {
            context.WeatherObservations.AddRange(
                new WeatherObservation
                {
                    Date = new DateTime(2020, 05, 03, 9, 0, 0),
                    Name = "Bunden af bubbers badekar",
                    Latitude = 23.45224,
                    Longitude = 19.353,
                    TemperatureCelsius = 33.1,
                    Humidity_Percentage = 10,
                    Pressure_Millibar = 9.2
                },
                new WeatherObservation
                {
                    Date = new DateTime(2020, 02, 03, 1, 50, 0),
                    Name = "Himmelbjerget",
                    Latitude = 12.46733,
                    Longitude = 2.2352,
                    TemperatureCelsius = 33.1,
                    Humidity_Percentage = 10,
                    Pressure_Millibar = 9.2
                },
            new WeatherObservation
                {
                    Date = new DateTime(2020, 11, 15, 9, 0, 0),
                    Name = "Hjemme paa gaarden",
                    Latitude = 56.158150,
                    Longitude = 10.212030,
                    TemperatureCelsius = 33.1,
                    Humidity_Percentage = 10,
                    Pressure_Millibar = 9.2
                }
            );
            context.SaveChanges();
        }
    }
}