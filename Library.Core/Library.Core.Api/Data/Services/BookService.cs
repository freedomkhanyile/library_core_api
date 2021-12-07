using Library.Core.Api.Data.Models;
using Library.Core.Api.Data.Services.Contracts;
using Library.Core.Api.Data.UnitOfWork;

namespace Library.Core.Api.Data.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var books = await _unitOfWork.QueryAsync<Book>();
            if (books.Any())
            {
                return books.FirstOrDefault(x => x.Id == id);
            }
            else { return null; }
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _unitOfWork.QueryAsync<Book>();
        }

        public async Task<int> CreateBookAsync(Book book)
        {
            if (await _unitOfWork.AddAsync(book) > 0)
                await _unitOfWork.CommitAsync();
            else
                return 0;

            return book.Id;

        }

        public async Task<int> UpdateBookAsync(Book book)
        {
            if (await _unitOfWork.UpdateAsync(book) > 0)
                await _unitOfWork.CommitAsync();
            else
                return 0;

            return book.Id;
        }

        public async Task<int> DeleteBookAsync(Book book)
        {
            if (await _unitOfWork.RemoveAsync(book) > 0)
                await _unitOfWork.CommitAsync();
            else
                return 0;

            return book.Id;
        }
    }
}
