using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations.Entities
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole<Guid>> builder)
        {
            //Config Table Schema ------------------------------------------------


            //Seeding Data ------------------------------------------------

            //Seed Users Roles

            //Admin User Related to Roles (Administrators,Supervisors,Users)
            builder.HasData(new List<ApplicationUserRole<Guid>>()
            {
               
               new ApplicationUserRole<Guid>
               {
                   UserId= Guid.Parse("1b345d5d-4714-401f-b124-32836d210679"),
                   RoleId= Guid.Parse("557D96C5-6AB6-40B9-B2A3-47166E861366")
               },

               new ApplicationUserRole<Guid>
               {
                   UserId= Guid.Parse("1b345d5d-4714-401f-b124-32836d210679"),
                   RoleId= Guid.Parse("447D96C5-6AB6-40B9-B2A3-47166E861366")
               },

               new ApplicationUserRole<Guid>
               {
                   UserId= Guid.Parse("1b345d5d-4714-401f-b124-32836d210679"),
                   RoleId= Guid.Parse("337D96C5-6AB6-40B9-B2A3-47166E861366")
               }

            });

            //Supervisor User Related to Roles (Supervisors,Users)
            builder.HasData(new List<ApplicationUserRole<Guid>>()
            {
               new ApplicationUserRole<Guid>
               {
                   UserId= Guid.Parse("2b345d5d-4714-401f-b124-32836d210679"),
                   RoleId= Guid.Parse("447D96C5-6AB6-40B9-B2A3-47166E861366")
               },

               new ApplicationUserRole<Guid>
               {
                   UserId= Guid.Parse("2b345d5d-4714-401f-b124-32836d210679"),
                   RoleId= Guid.Parse("337D96C5-6AB6-40B9-B2A3-47166E861366")
               }
            });

            //user User Related to Roles (Users)
            builder.HasData(new List<ApplicationUserRole<Guid>>()
            {
               new ApplicationUserRole<Guid>
               {
                   UserId= Guid.Parse("3b345d5d-4714-401f-b124-32836d210679"),
                   RoleId= Guid.Parse("337D96C5-6AB6-40B9-B2A3-47166E861366")
               }
            });
        }
    }
}
