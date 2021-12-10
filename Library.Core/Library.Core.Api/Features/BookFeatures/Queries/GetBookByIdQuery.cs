using Library.Core.Api.Data.Models;
using Library.Core.Api.Data.UnitOfWork;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Core.Api.Features.BookFeatures.Queries
{
    public class GetBookByIdQuery: IRequest<Book>
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
