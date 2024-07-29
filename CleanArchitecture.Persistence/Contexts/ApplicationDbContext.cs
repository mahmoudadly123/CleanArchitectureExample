using CleanArchitecture.Domain.Aggregates;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CleanArchitecture.Persistence.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        #region Constructors

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }

        #endregion

        #region Configuration

        
        // Called When Database being Generated using Migration , can use it to config tables with rules
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        #endregion

        #region DbSets

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        #endregion
    }
}
