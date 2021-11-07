using Data.Models;
using Data.ViewModels;

namespace Data.Extensions
{
    public static class BookExtensions
    {
        public static Book ToEntity(this BookViewModel model)
        {
            return new Book {
                Id = model.BookId,
                BookName = model.BookName,
                ISBN = model.ISBN,
                Year = model.Year
            };
        }

        public static BookViewModel ToEntity(this Book model)
        {
            return new BookViewModel {
                BookId = model.Id,
                BookName = model.BookName,
                ISBN = model.ISBN,
                Year = model.Year
            };
        }
    }
}
