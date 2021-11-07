using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) :
            base(options)
        {
        }
    }
}
