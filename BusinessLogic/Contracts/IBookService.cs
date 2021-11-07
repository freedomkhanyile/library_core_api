using System.Threading.Tasks;
using Data.ViewModels;

namespace BusinessLogic.Contracts
{
    public interface IBookService
    {
        BookViewModel GetById(int id);

        BookListViewModel GetBooks();

        Task<BookViewModel> CreateBook(CreateBookViewModel model);

        Task<BookViewModel> UpdateBook(int id, UpdateBookViewModel model);

        Task<bool> DeleteBookAsync(int id);
    }
}
