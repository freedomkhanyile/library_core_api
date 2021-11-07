using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) :
            base(options)
        {
        }

        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Book>(Book =>
                {
                    Book.HasKey(b => b.Id);
                    Book.Property(b => b.BookName).IsRequired();
                    Book.Property(b => b.ISBN).IsRequired();
                });
        }
    }
}
