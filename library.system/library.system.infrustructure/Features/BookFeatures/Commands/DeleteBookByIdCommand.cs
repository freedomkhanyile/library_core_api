using library.system.infrustructure.Data.UnitOfWork;
using library.system.infrustructure.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace library.system.infrustructure.Features.BookFeatures.Commands
{
    public class DeleteBookByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteBookByIdCommandHandler : IRequestHandler<DeleteBookByIdCommand, int>
        {
            private readonly IUnitOfWork _uow;
            public DeleteBookByIdCommandHandler(IUnitOfWork uow)
            {
                _uow = uow;
            }

            public async Task<int> Handle(DeleteBookByIdCommand command, CancellationToken cancellationToken)
            {
                var books = await _uow.QueryAsync<Book>();
                var bookToBeDeleted = books.FirstOrDefault(x => x.Id == command.Id);

                if (bookToBeDeleted == null) return default;
                await _uow.RemoveAsync(bookToBeDeleted);
                await _uow.CommitAsync();
                return command.Id;
            }
        }

    }
}
