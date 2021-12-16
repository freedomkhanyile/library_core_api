using AutoMapper;
using library.system.api.ViewModels.Book;
using library.system.infrustructure.Features.BookFeatures.Commands;
using library.system.infrustructure.Models;

namespace library.system.api.Helpers.AutoMapper
{
    public class BookAutoMapperProfile : Profile
    {
        public BookAutoMapperProfile()
        {
            CreateMap<Book, BookViewModel>();
            CreateMap<Book, BookCreateViewModel>();

            // Map to CreateBookCommand?
            CreateMap<BookCreateViewModel, CreateBookCommand>();

            // Map from CreateBookCommand?
            CreateMap<CreateBookCommand, BookCreateViewModel>();

            CreateMap<BookUpdateViewModel, UpdateBookCommand>();
            CreateMap<Book, BookUpdateViewModel>();

        }
    }
}
