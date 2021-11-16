using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Contracts;
using Data.Contracts;
using Data.Extensions;
using Data.Models;
using Data.ViewModels;

namespace BusinessLogic.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _uow;

        public BookService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<BookViewModel> CreateBookAsync(CreateBookViewModel model)
        {
            // transform the model to an entity.
            var book = model.ToEntity();

            // EF Unit of work add.
            _uow.Add (book);

            // Commit changes
            await _uow.CommitAsync();

            // return view model
            return book.ToModel();
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            // Return the first occurance of the Id and convert to entity to delete.
            var bookToDelete =
                GetQuery().FirstOrDefault(b => b.Id == id);

            // Throw exception not found.
            if (bookToDelete == null)
            {
                throw new System.Exception($"Book with id: {id} not found");
            }

            // Remove book from our UOW instance
            _uow.Remove(bookToDelete);

            // Persist database effectively.
            await _uow.CommitAsync();
            return true;
        }

        public BookListViewModel GetBooks()
        {
            // Instantiate a book list object to store our data.
            var bookList = new BookListViewModel();
            // Get books by query UoW
            var books = GetQuery();

            if (books.Count() > 0)
            {
                // map fields 
                bookList.books = books.Select(x => x.ToModel()).ToList();
                bookList.Count = books.Count();
            }

            return bookList;
        }

        public BookViewModel GetById(int id)
        {
            // get the first instance of the bookid based on id parameter.
            var book = GetQuery().FirstOrDefault(x => x.Id == id);
           
            return book != null ? book.ToModel() : throw new System.Exception($"Book with id: {id} not found");
        }

        public async Task<BookViewModel> UpdateBookAsync(int id, UpdateBookViewModel model)
        {
            // get the first instance of the bookid based on id parameter.
            var book = GetQuery().FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                throw new System.Exception($"Book with id: {id} not found");
            }

            // Update book fields here.
             book.BookName = model.BookName;
            book.ISBN = model.ISBN;
            book.Year = model.Year;
            await  _uow.CommitAsync();

            return GetById(id);

        }

        private IQueryable<Book> GetQuery()
        {
            var q = _uow.Query<Book>();
            var books = q.ToList();
            return books.AsQueryable();
        }
    }
}
