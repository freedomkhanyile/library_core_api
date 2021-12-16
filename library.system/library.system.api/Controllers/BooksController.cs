using AutoMapper;
using library.system.api.ViewModels.Book;
using library.system.infrustructure.Features.BookFeatures.Commands;
using library.system.infrustructure.Features.BookFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace library.system.api.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BooksController> _logger;
        private readonly IMapper _mapper;
        public BooksController(IMediator mediator, ILogger<BooksController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
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

        /// <summary>
        /// Create a book by book id
        /// </summary>
        /// <returns command="CreateBookCommand"></returns>

        [HttpPost]
        public async Task<IActionResult> PostAsync(BookCreateViewModel model)
        {
            var command = _mapper.Map<CreateBookCommand>(model);
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Create a book by book id
        /// </summary>
        /// <param name="id"></param>
        /// <returns command="UpdateBookCommand"></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, BookUpdateViewModel model)
        {
            if (model == null)
            {
                _logger.LogError($"no data provided @ : {DateTime.UtcNow}");
                return BadRequest();
            }
            if(id != model.Id)
            {
                _logger.LogError($"data provided has no match @ : {DateTime.UtcNow}");
                return BadRequest();
            }

            var command = _mapper.Map<UpdateBookCommand>(model);

            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _mediator.Send(new DeleteBookByIdCommand { Id = id }));
        }
    }
}
