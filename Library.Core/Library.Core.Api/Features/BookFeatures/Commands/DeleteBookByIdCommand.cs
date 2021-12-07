using Library.Core.Api.Data.Services.Contracts;
using MediatR;

namespace Library.Core.Api.Features.BookFeatures.Commands
{
    public class DeleteBookByIdCommand: IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteBookByIdCommandHandler : IRequestHandler<DeleteBookByIdCommand, int>
        {
            private readonly IBookService _service;
            public DeleteBookByIdCommandHandler(IBookService service)
            {
                _service = service;
            }

            public async Task<int> Handle(DeleteBookByIdCommand command, CancellationToken cancellationToken)
            {
               var bookToBeDeleted = await _service.GetBookByIdAsync(command.Id);
                if (bookToBeDeleted == null) return default;
                return await _service.DeleteBookAsync(bookToBeDeleted);
            }
        }

    }
}
