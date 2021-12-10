using Library.Core.Api.Data.Models;
using Library.Core.Api.Data.UnitOfWork;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Core.Api.Features.BookFeatures.Commands
{
    public class UpdateBookCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string ISBN { get; set; }

        public string BarCode { get; set; }
        public int Year { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string InitialCondition { get; set; }

        public decimal OrderCost { get; set; }

        public string Publisher { get; set; }

        public string ModifyUserId { get; set; }

        public int StatusId { get; set; }

        public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
        {
            private readonly IUnitOfWork _uow;
            public UpdateBookCommandHandler(IUnitOfWork uow)
            {
                _uow = uow;
            }

            public async Task<int> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
            {
                var books = await _uow.QueryAsync<Book>();
                var bookToBeUpdated = books.FirstOrDefault(x => x.Id == command.Id);
                if (bookToBeUpdated == null) return default;
                else
                {
                    bookToBeUpdated.Title = command.Title;
                    bookToBeUpdated.ISBN = command.ISBN;
                    bookToBeUpdated.BarCode = command.BarCode;
                    bookToBeUpdated.Year = command.Year;
                    bookToBeUpdated.Type = command.Type;
                    bookToBeUpdated.BarCode = command.BarCode;
                    bookToBeUpdated.Publisher = command.Publisher;
                    bookToBeUpdated.OrderCost = command.OrderCost;
                    bookToBeUpdated.InitialCondition = command.InitialCondition;
                    bookToBeUpdated.ModifyDate = DateTime.UtcNow;
                    bookToBeUpdated.ModifyUserId = command.ModifyUserId;
                    bookToBeUpdated.StatusId = command.StatusId;

                     await _uow.UpdateAsync(bookToBeUpdated);
                    await _uow.CommitAsync();
                    return command.Id;

                }

            }
        }

    }
}
