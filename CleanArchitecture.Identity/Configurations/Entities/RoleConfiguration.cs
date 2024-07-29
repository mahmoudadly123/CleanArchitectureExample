using CleanArchitecture.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations.Entities
{
    public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole<Guid>> builder)
        {
            //Config Table Schema ------------------------------------------------
          
            //Seeding Data ------------------------------------------------

            //Seed Roles
            builder.HasData(new List<ApplicationRole<Guid>>()
            {
                new ApplicationRole<Guid>()
                {
                    Id=Guid.Parse("557D96C5-6AB6-40B9-B2A3-47166E861366"),
                    Name="Administrators",
                    NormalizedName="ADMINISTRATORS"
                },
                new ApplicationRole<Guid>()
                {
                    Id=Guid.Parse("447D96C5-6AB6-40B9-B2A3-47166E861366"),
                    Name="Supervisors",
                    NormalizedName="SUPERVISORS"
                },
                new ApplicationRole<Guid>()
                {
                    Id=Guid.Parse("337D96C5-6AB6-40B9-B2A3-47166E861366"),
                    Name="Users",
                    NormalizedName="USERS"
                }
            });
        }
    }
}
