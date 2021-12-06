using Library.Core.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Api.Data.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public async Task<int> SaveChangesAsync() { return await base.SaveChangesAsync(); }
    }
}
