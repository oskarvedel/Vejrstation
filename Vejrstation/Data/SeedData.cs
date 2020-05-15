/*
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
            if (!context.WeatherObservation.Any())
                SeedExpenses(context);
        }

        static void SeedAccounts(ApplicationDbContext context)
        {
            context.Accounts.AddRange(
                // Seed manager
                new EfAccount
                {
                    Email = "boss@m.dk",
                    PwHash = HashPassword("asdfQWER", BcryptWorkfactor),
                    IsManager = true
                },
                // Seed some models
                new EfAccount
                {
                    Email = "nc@m.dk",
                    PwHash = HashPassword("Pas123", BcryptWorkfactor),
                    IsManager = false
                },
                new EfAccount
                {
                    Email = "hc@m.dk",
                    PwHash = HashPassword("Pas123", BcryptWorkfactor),
                    IsManager = false
                },
                new EfAccount
                {
                    Email = "al@m.dk",
                    PwHash = HashPassword("Pas123", BcryptWorkfactor),
                    IsManager = false
                },
                new EfAccount
                {
                    Email = "jk@m.dk",
                    PwHash = HashPassword("Pas123", BcryptWorkfactor),
                    IsManager = false
                }
                );
            context.SaveChanges();
        }

        private static void SeedJobs(ApplicationDbContext context)
        {
            context.Jobs.AddRange(
                new EfJob
                {
                    Customer = "Vogue",
                    StartDate = new DateTimeOffset(2020, 05, 03, 9, 0, 0, TimeSpan.Zero),
                    Days = 2,
                    Location = "Tower Brigde London",
                    Comments = "Outdoor location!"
                },
                new EfJob
                {
                    Customer = "Vogue",
                    StartDate = new DateTimeOffset(2020, 06, 2, 10, 0, 0, TimeSpan.Zero),
                    Days = 1,
                    Location = "Hyde Park London",
                    Comments = "Only if sunshine."
                },
                new EfJob
                {
                    Customer = "Elle",
                    StartDate = new DateTimeOffset(2020, 05, 28, 8, 0, 0, TimeSpan.Zero),
                    Days = 1,
                    Location = "Eiffel Tower Paris",
                    Comments = ""
                },
                new EfJob
                {
                    Customer = "Versace",
                    StartDate = new DateTimeOffset(2020, 05, 29, 9, 0, 0, TimeSpan.FromHours(2)),
                    Days = 2,
                    Location = "Milan, Italy",
                    Comments = ""
                },
                new EfJob
                {
                    Customer = "Hugo Boss",
                    StartDate = new DateTimeOffset(2020, 05, 30, 8, 30, 0, TimeSpan.Zero),
                    Days = 2,
                    Location = "Alexanderplatz, Berlin, Tyskland",
                    Comments = ""
                }
                );
            context.SaveChanges();
        }
    }
}
*/
