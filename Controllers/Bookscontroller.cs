using System;
using System.Threading.Tasks;
using BusinessLogic.Contracts;
using Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Controllers
{
    [ApiController]
    [Route("api/book")]
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

        /// <summary>
        /// Returns all the books in our data storage.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookService.GetBooks());
        }

        /// <summary>
        /// creates a book record against our data storage.
        /// </summary>
        /// <param name="CreateBookViewModel"></param>
        /// <returns>BookViewModel</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateBookViewModel model)
        {
            try
            {
                var book = await _bookService.CreateBookAsync(model);
                _logger
                    .LogInformation($"Book with name :{0} was created successfully",book.BookName);
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger
                    .LogError("book:create has encountered an issue trying to serve client.");
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// updates book using the view mopdel
        /// </summary>
        /// <param name="UpdateBookViewModel"></param>
        /// <returns>BookViewModel</returns>
        [HttpPut]
        public async Task<IActionResult> Edit(UpdateBookViewModel model)
        {
            try
            {
                var book =
                    await _bookService.UpdateBookAsync(model.BookId, model);
                _logger
                    .LogInformation($"Book with name : { book.BookName} has been updated successfully");
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger
                    .LogError("book:edit has encountered an issue trying to serve client.");
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id) 
        {
           
            try
            {
                 var isDeleted = await _bookService.DeleteBookAsync(id);
                 _logger
                    .LogInformation($"Deletion completed successfully.");
                return Ok();
    
            }
            catch (Exception ex)
            {
                _logger
                    .LogError("book:delete has encountered an issue trying to serve client.");
                throw new Exception(ex.Message);
            }
        }


    }
}
