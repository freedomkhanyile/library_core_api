using System;
using Data.Models;
using Data.ViewModels;

namespace Data.Extensions
{
    public static class BookExtensions
    {
#region  BookViewModel
        public static Book ToEntity(this BookViewModel model)
        {
            return new Book {
                Id = model.BookId,
                BookName = model.BookName,
                ISBN = model.ISBN,
                Year = model.Year
            };
        }

        public static BookViewModel ToModel(this Book model)
        {
            return new BookViewModel {
                BookId = model.Id,
                BookName = model.BookName,
                ISBN = model.ISBN,
                Year = model.Year
            };
        }
#endregion



#region  CreateBookViewModel
        public static Book ToEntity(this CreateBookViewModel model)
        {
            return new Book {
                BookName = model.BookName,
                ISBN = model.ISBN,
                Year = model.Year,
                CreatedBy = model.CreatedBy,
                CreatedTimeStamp = DateTime.Now
            };
        }
#endregion



#region  UpdateBookViewModel
        public static void UpdateEntity(
            this UpdateBookViewModel model,
            Book entityToUpdate
        )
        {
            entityToUpdate.BookName = model.BookName;
            entityToUpdate.ISBN = model.ISBN;
            entityToUpdate.Year = model.Year;
        }

        public static UpdateBookViewModel
        ToUpdateViewModel(this BookViewModel model)
        {
            return new UpdateBookViewModel {
                BookId = model.BookId,
                BookName = model.BookName,
                ISBN = model.ISBN,
                Year = model.Year
            };
        }
#endregion
    }
}
