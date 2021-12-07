using Library.Core.Api.Data.Models;
using Library.Core.Api.Data.Services.Contracts;
using MediatR;

namespace Library.Core.Api.Features.BookFeatures.Queries
{
    public class GetBookByIdQuery: IRequest<Book>
    {
        public int Id { get; set; }

        public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
        {
            private readonly IBookService _service;
            public GetBookByIdQueryHandler(IBookService service)
            {
                _service = service;
            }
            public async Task<Book> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
            {
                var book = await _service.GetBookByIdAsync(query.Id);
#pragma warning disable CS8603 // Possible null reference return.
                return book ?? null;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }
    }
}
