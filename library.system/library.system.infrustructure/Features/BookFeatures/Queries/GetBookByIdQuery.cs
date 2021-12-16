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
    public class GetBookByIdQuery : IRequest<Book>
    {
        public int Id { get; set; }
    }
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IUnitOfWork _uow;
        public GetBookByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Book> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
        {

            var books = await _uow.QueryAsync<Book>();
            var book = books.FirstOrDefault(x => x.Id == query.Id);
            return book ?? null;
        }
 
    }
}
