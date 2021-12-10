using Library.Core.Api.Data.Models;
using Library.Core.Api.Data.UnitOfWork;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Core.Api.Features.BookFeatures.Queries
{
    public class GetAllBooksQuery: IRequest<IEnumerable<Book>>
    {
        public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
        {
            private readonly IUnitOfWork _uow;
            public GetAllBooksQueryHandler(IUnitOfWork uow)
            {
                _uow = uow;
            }

            public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
            {
                var bookList = await _uow.QueryAsync<Book>();
                if(bookList == null) return null;
                return bookList;
            }
        }
    }
}
