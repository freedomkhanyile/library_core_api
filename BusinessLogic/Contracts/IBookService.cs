using System.Threading.Tasks;
using Data.ViewModels;

namespace BusinessLogic.Contracts
{
    public interface IBookService
    {
        BookViewModel GetById(int id);

        BookListViewModel GetBooks();

        Task<BookViewModel> CreateBookAsync(CreateBookViewModel model);

        Task<BookViewModel> UpdateBookAsync(int id, UpdateBookViewModel model);

        Task<bool> DeleteBookAsync(int id);
    }
}
