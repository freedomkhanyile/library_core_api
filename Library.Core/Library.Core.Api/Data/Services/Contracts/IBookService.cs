using Library.Core.Api.Data.Models;

namespace Library.Core.Api.Data.Services.Contracts
{
    public interface IBookService
    {
        Task<int> CreateBookAsync(Book book);
        Task<int> DeleteBookAsync(Book book);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<int> UpdateBookAsync(Book book);
    }
}