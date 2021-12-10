using Library.Core.Api.Data.Models;
using Library.Core.Api.Data.UnitOfWork;
using MediatR;

namespace Library.Core.Api.Features.BookFeatures.Commands
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
