using library.system.infrustructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.system.infrustructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Lender> Lenders { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<BookingHistory> BookingHistories { get; set; }

        public async Task<int> SaveChangesAsync() { return await base.SaveChangesAsync(); }
    }
}
