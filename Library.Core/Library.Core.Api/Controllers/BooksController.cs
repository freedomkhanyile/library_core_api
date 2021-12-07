using Library.Core.Api.Features.BookFeatures.Commands;
using Library.Core.Api.Features.BookFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Core.Api.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BooksController> _logger;
        public BooksController(IMediator mediator, ILogger<BooksController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Get books in the system
        /// </summary>
        /// <returns>List of books</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetAllBooksQuery()));
        }
        /// <summary>
        /// Gets a book by book id
        /// </summary>
        /// <param name="id"></param>
        /// <returns model="Book"></returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {

            return Ok(await _mediator.Send(new GetBookByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateBookCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateBookCommand command)
        {
            if (command == null)
            {
                _logger.LogError($"no data provided @ : {DateTime.UtcNow}");
                return BadRequest();
            }
            if (id != command.Id)
            {
                _logger.LogError($"data provided has no match @ : {DateTime.UtcNow}");
                return BadRequest();
            }

            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _mediator.Send(new DeleteBookByIdCommand { Id = id }));
        }
    }
}
