using library.system.infrustructure.Data.UnitOfWork;
using library.system.infrustructure.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace library.system.infrustructure.Features.BookFeatures.Queries
{
    public class GetAllBooksQuery : IRequest<IEnumerable<Book>>
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
                if (bookList == null) return null;
                return bookList;
            }        
        }
    }
}
