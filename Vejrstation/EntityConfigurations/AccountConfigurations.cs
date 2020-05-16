using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vejrstation.Entities;
using static BCrypt.Net.BCrypt;


namespace Vejrstation.EntityConfigurations
{
    public class AccountConfigurations : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(new Account
            {
                Id = 1,
                UserName = "Flydende vejrstation 999",
                PasswordHash = "asdfasdf12341234"
            },
                new Account
                {
                    Id = 2,
                    UserName = "John_1954",
                    PasswordHash = HashPassword("mitPassword1", Settings.BCryptWorkFactor)
                },
                // Seed some models
                new Account
                {
                    Id = 3,
                    UserName = "Jesper Theilgaard",
                    PasswordHash = HashPassword("mitPassword2", Settings.BCryptWorkFactor)
                },
                new Account
                {
                    Id = 4,
                    UserName = "Peter Qvortrup Geisling",
                    PasswordHash = HashPassword("mitPassword3", Settings.BCryptWorkFactor)
                },
                new Account
                {
                    Id = 5,
                    UserName = "Dr. Pjuskibusk",
                    PasswordHash = HashPassword("mitPassword4", Settings.BCryptWorkFactor)
                });
        }
        
    }
}