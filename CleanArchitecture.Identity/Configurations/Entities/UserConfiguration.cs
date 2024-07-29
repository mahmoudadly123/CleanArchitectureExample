using CleanArchitecture.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations.Entities
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser<Guid>>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser<Guid>> builder)
        {
            //Config Table Schema ------------------------------------------------
           

            //Seeding Data ------------------------------------------------
            var hasher=new PasswordHasher<ApplicationUser<Guid>>();

            //Seed Users
            builder.HasData(new List<ApplicationUser<Guid>>()
            {
               new ApplicationUser<Guid>
               {
                   Id=Guid.Parse("1b345d5d-4714-401f-b124-32836d210679"),
                   UserName="admin",
                   NormalizedUserName="ADMIN",
                   Email="admin@gmail.com",
                   NormalizedEmail="ADMIN@GMAIL.COM",
                   PasswordHash=hasher.HashPassword(null,"P@ssw0rd")
               },

               new ApplicationUser<Guid>
               {
                   Id=Guid.Parse("2b345d5d-4714-401f-b124-32836d210679"),
                   UserName="supervisor",
                   NormalizedUserName="SUPERVISOR",
                   Email="supervisor@gmail.com",
                   NormalizedEmail="SUPERVISOR@GMAIL.COM",
                   PasswordHash=hasher.HashPassword(null,"P@ssw0rd")
               },

               new ApplicationUser<Guid>
               {
                   Id=Guid.Parse("3b345d5d-4714-401f-b124-32836d210679"),
                   UserName="user",
                   NormalizedUserName="USER",
                   Email="user@gmail.com",
                   NormalizedEmail="USER@GMAIL.COM",
                   PasswordHash=hasher.HashPassword(null,"P@ssw0rd")
               }

            });
        }
    }
}
