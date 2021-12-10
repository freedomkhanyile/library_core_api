
using Library.Core.Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Library.Core.Api.Data.Context
{
    public interface IApplicationDbContext
    {
        DbSet<Book> Books { get; set; }
        Task<int> SaveChangesAsync();
    }
}