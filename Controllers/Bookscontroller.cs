using System.Threading.Tasks;
using BusinessLogic.Contracts;
using Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Bookscontroller : ControllerBase
    {
        private static readonly string[]
            Books =
                new []
                { "Snow White", "Beauty and Beast", "Shake Spear", "History" };

        private readonly ILogger<Bookscontroller> _logger;

        private readonly IBookService _bookService;

        public Bookscontroller(
            ILogger<Bookscontroller> logger,
            IBookService bookService
        )
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookService.GetBooks());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookViewModel model)
        {
            var book = await _bookService.CreateBook(model);
            _logger
                .LogInformation($"Book with name :{book.BookName} was created successfully");
            return Ok(book);
        }
    }
}
