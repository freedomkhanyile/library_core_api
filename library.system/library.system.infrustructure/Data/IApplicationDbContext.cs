using library.system.infrustructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace library.system.infrustructure.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<BookAuthor> BookAuthors { get; set; }
        DbSet<BookingHistory> BookingHistories { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Lender> Lenders { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync();
    }
}