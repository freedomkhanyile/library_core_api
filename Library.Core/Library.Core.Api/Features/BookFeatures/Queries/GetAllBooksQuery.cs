using Library.Core.Api.Data.Models;
using Library.Core.Api.Data.Services.Contracts;
using MediatR;

namespace Library.Core.Api.Features.BookFeatures.Queries
{
    public class GetAllBooksQuery: IRequest<IEnumerable<Book>>
    {
        public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
        {
            private readonly IBookService _service;

            public GetAllBooksQueryHandler(IBookService service)
            {
                _service = service;
            }

            public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
            {
                var bookList = await _service.GetAllBooksAsync();
                if(bookList == null) return null;
                return bookList;
            }
        }
    }
}
