using Library.API.Application.Commands;
using Library.API.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBookQueries _bookQueries;

        public BookController(IMediator mediator, IBookQueries bookQueries)
        {
            _mediator = mediator;
            _bookQueries = bookQueries;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookAsync([FromBody] BookDTO book)
        {
            //BookDTO book = JsonSerializer.Deserialize<BookDTO>(body)!;
            bool commandResult = await _mediator.Send(new CreateBookCommand(book));

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBookAsync([FromBody] BookDTO book)
        {
            bool commandResult = await _mediator.Send(new UpdateBookCommand(book));

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DelteBookAsync([FromBody] BookDTO book)
        {
            bool commandResult = await _mediator.Send(new DeleteBookCommand(book));

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            try 
            {
                var books = await _bookQueries.GetAllBooksAsync();

                return Ok(books);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error: {ex.Message}. \n Stack Trace - {ex.StackTrace}");
                return NotFound();
            }
        }

        [Route("id-{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            try
            {
                var book = await _bookQueries.GetBookByIdAsync(id);

                return Ok(book);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("isbn-{isbn}")]
        [HttpGet]
        public async Task<IActionResult> GetBookByISBNAsync(string ISBN)
        {
            try
            {
                var book = await _bookQueries.GetBookByISBNAsync(ISBN);

                return Ok(book);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
