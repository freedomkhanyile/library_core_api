using Library.Core.Api.Data.Models;
using Library.Core.Api.Data.UnitOfWork;
using MediatR;

namespace Library.Core.Api.Features.BookFeatures.Commands
{
    public class CreateBookCommand : IRequest<int>
    {
        public string ISBN { get; set; }

        public string BarCode { get; set; }
        public int Year { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string InitialCondition { get; set; }

        public decimal OrderCost { get; set; }

        public string Publisher { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateUserId { get; set; }

        public DateTime ModifyDate { get; set; }

        public string ModifyUserId { get; set; }

        public int StatusId { get; set; }

        public class CreateBookCommanHandler : IRequestHandler<CreateBookCommand, int>
        {
            private readonly IUnitOfWork _uow;
            public CreateBookCommanHandler(IUnitOfWork uow)
            {
                _uow = uow;
            }
            public async Task<int> Handle(CreateBookCommand command, CancellationToken cancellationToken)
            {
                var book = new Book();
                book.Title = command.Title;
                book.Year = command.Year;
                book.Type = command.Type;
                book.InitialCondition = command.InitialCondition;
                book.OrderCost = command.OrderCost;
                book.Publisher = command.Publisher;
                book.ISBN = command.ISBN;
                book.BarCode = command.BarCode;
                book.CreateDate = DateTime.UtcNow;
                book.CreateUserId = command.CreateUserId;
                book.ModifyDate = DateTime.UtcNow;
                book.ModifyUserId = command.ModifyUserId;
                book.StatusId = command.StatusId;

                await _uow.AddAsync(book);
                await _uow.CommitAsync();

                return book.Id;
            }
        }
    }
}
