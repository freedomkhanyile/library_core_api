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

        public Bookscontroller(ILogger<Bookscontroller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Books);
        }
    }
}
