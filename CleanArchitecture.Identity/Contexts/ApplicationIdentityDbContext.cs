using CleanArchitecture.Identity.Configurations.Entities;
using CleanArchitecture.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Identity.Contexts
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser<Guid>,ApplicationRole<Guid>,Guid>
    {
        #region Constructors
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options) { }
        #endregion

        #region Configuration
        // Called When Database being Generated using Migration , can use it to config tables with rules
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
        #endregion

        #region DbSets

        #endregion
    }
}
