using Library.Application.Books.Commands.CreateBookCommand;
using Library.Application.Books.Commands.DeleteBookCommand;
using Library.Application.Books.Commands.UpdateBookCommand;
using Library.Application.Books.Queries.GetBookById;
using Library.Application.Books.Queries.GetBookByISBN;
using Library.Application.Books.Queries.GetBooksWithPagination;
using Library.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a book.
        /// </summary>
        /// <param name="createBookCommand"></param>
        /// <returns>A newly created book</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Book/
        ///     {
        ///         "ISBN": "1234567701",
        ///         "Name": "dz",
        ///         "Genre": "zz",
        ///         "Description": "zz",
        ///         "AuthorId": "1",
        ///         "BorrowingTime": "2023-01-01T00:00:00",
        ///         "ReturningTime": "2023-02-02T00:00:00"
        ///    }
        ///
        /// </remarks>
        /// <response code="200"> Returns the newly created item</response>
        /// <response code="400"> If request body has incorrect values</response>
        /// <response code="401"> If unauthorized request happend</response>
        /// <response code="500"> If somethin went wrong</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateBookAsync([FromBody] CreateBookCommand createBookCommand)
        {
            BookDTO result = await _mediator.Send(createBookCommand);

            return Ok(result);
        }

        /// <summary>
        /// Updates a book.
        /// </summary>
        /// <param name="updateBookCommand"></param>
        /// <returns>A updated book</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Book/
        ///     {
        ///         "Id": "71"
        ///         "ISBN": "1234567701",
        ///         "Name": "dz",
        ///         "Genre": "zz",
        ///         "Description": "zz",
        ///         "AuthorId": "6",
        ///         "BorrowingTime": "2023-01-01T00:00:00",
        ///         "ReturningTime": "2023-02-02T00:00:00"
        ///    }
        ///
        /// </remarks>
        /// <response code="200">Returns the updated item</response>
        /// <response code="400">If request body has incorrect values</response>
        /// <response code="401">If unauthorized request happend</response>
        /// <response code="404"> If entity wasnt found</response>
        /// <response code="500">If request failed due to server error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        [Authorize]
        
        public async Task<IActionResult> UpdateBookAsync([FromBody] UpdateBookCommand updateBookCommand)
        {
            BookDTO result = await _mediator.Send(updateBookCommand);

            return Ok(result);
        }

        /// <summary>
        /// Deletes a book.
        /// </summary>
        /// <param name="deleteBookCommand"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/Book/
        ///     {
        ///         "id": "71",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">If request processed correctly</response>
        /// <response code="400">If request body has incorrect values</response>
        /// <response code="401"> If unauthorized request happend</response>
        /// <response code="404"> If entity wasnt found</response>
        /// <response code="500">If request failed due to server error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DelteBookAsync([FromBody] DeleteBookCommand deleteBookCommand)
        {
            await _mediator.Send(deleteBookCommand);

            return Ok();
        }

        /// <summary>
        /// Gets books with pagination.
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns>Certain amount of books</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /api/Book?pageNumber=1&pageSize=3
        ///
        /// </remarks>
        /// <response code="200">Certain amount of books</response>
        /// <response code="404">If nothing found or some exception happened</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetPaginatedBooksAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 3)
        {
            var books = await _mediator.Send(new GetBooksWithPaginationQuery(pageSize, pageNumber));
            
            return Ok(books);
        }

        /// <summary>
        /// Gets book with specified id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Book with specified id</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /api/Book/id/1
        ///
        /// </remarks>
        /// <response code="200">Returns the book with specified id</response>
        /// <response code="404">If nothing found or some exception happened</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id:int}")]
        [HttpGet]
        
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(id));

            return Ok(book);
        }

        /// <summary>
        /// Gets book with specified isbn.
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns>Book with specified isbn</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /api/Book/isbn/1111111111
        ///
        /// </remarks>
        /// <response code="200">Returns the book with specified isbn</response>
        /// <response code="404">If nothing found or some exception happened</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("isbn/{isbn}")]
        [HttpGet]
        
        public async Task<IActionResult> GetBookByISBNAsync(string isbn)
        {
            var book = await _mediator.Send(new GetBookByISBNQuery(isbn));

           return Ok(book);
        }
    }
}
