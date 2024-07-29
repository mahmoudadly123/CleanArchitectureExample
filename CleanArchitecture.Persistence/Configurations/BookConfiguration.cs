using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //Config Tables
            ConfigureBooksTable(builder);

            //Seeds Data
            SeedsBooksTable(builder);
        }


        #region Configure

        private void ConfigureBooksTable(EntityTypeBuilder<Book> builder)
        {
            //Config Table Schema ------------------------------------------------

            builder.ToTable("Library.Books")
                .HasKey(u => u.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();
        }

        #endregion

        #region Seeds

        private void SeedsBooksTable(EntityTypeBuilder<Book> builder)
        {
            //Seeding Data ------------------------------------------------

            //Seed books
            builder.HasData(new List<Book>()
            {
                Book.Create(-1,"OOP C#","Lean OOP inside C#","Programming",true),
                Book.Create(-2,"Rust","Lean Rust Programming","Programming",true),
                Book.Create(-3,"Android","Lean Android Programming","Mobile",true),
                Book.Create(-4,"Flutter","Lean Flutter Programming","Mobile",true),
                Book.Create(-5,"DevExpress","Lean DevExpress For Desktop Apps","Desktop",false),
                Book.Create(-6,"EntityFrameworkCore","Lean EntityFrameworkCore","DataAccess",false)
            });
        }

        #endregion

    }
}
