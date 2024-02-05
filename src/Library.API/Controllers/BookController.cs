using Azure;
using Library.API.Application.Commands;
using Library.API.Application.Queries;
using Library.Domain.Exceptions;
using Library.Domain.Model;
using Library.Infrastructure.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        ///         "Author": "zz",
        ///         "BorrowingTime": "2023-01-01T00:00:00",
        ///         "ReturningTime": "2023-02-02T00:00:00"
        ///    }
        ///
        /// </remarks>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If request body has incorrect values</response>
        /// <response code="401">If unauthorized request happend</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> CreateBookAsync([FromBody] CreateBookCommand createBookCommand)
        {
            Book result = await _mediator.Send(createBookCommand);

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
        ///     POST /api/Book/
        ///     {
        ///         "Id": "71"
        ///         "ISBN": "1234567701",
        ///         "Name": "dz",
        ///         "Genre": "zz",
        ///         "Description": "zz",
        ///         "Author": "zz",
        ///         "BorrowingTime": "2023-01-01T00:00:00",
        ///         "ReturningTime": "2023-02-02T00:00:00"
        ///    }
        ///
        /// </remarks>
        /// <response code="200">Returns the updated item</response>
        /// <response code="400">If request body has incorrect values</response>
        /// <response code="401">If unauthorized request happend</response>
        /// <response code="500">If request failed due to server error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateBookAsync([FromBody] UpdateBookCommand updateBookCommand)
        {
            Book result = await _mediator.Send(updateBookCommand);

            return Ok(result);
        }

        /// <summary>
        /// Deletes a book.
        /// </summary>
        /// <param name="deleteBookCommand"></param>
        /// <returns>A deleted book</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Book/
        ///     {
        ///         "ISBN": "1234567701",
        ///         "Name": "dz",
        ///         "Genre": "zz",
        ///         "Description": "zz",
        ///         "Author": "zz",
        ///         "BorrowingTime": "2023-01-01T00:00:00",
        ///          "ReturningTime": "2023-02-02T00:00:00"
        ///    }
        ///
        /// </remarks>
        /// <response code="200">Returns the deleted item</response>
        /// <response code="400">If request body has incorrect values</response>
        /// <response code="401"> If unauthorized request happend</response>
        /// <response code="500">If request failed due to server error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> DelteBookAsync([FromBody] DeleteBookCommand deleteBookCommand)
        {
            await _mediator.Send(deleteBookCommand);

            return Ok();
        }

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns>All books</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /api/Book/
        ///
        /// </remarks>
        /// <response code="200">Returns the all books</response>
        /// <response code="404">If nothing found or some exception happened</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllbooksAsync()
        {
            var books = await _bookQueries.GetAllBooksAsync();

            if (books is not null)
                return Ok(books);
            else
                return NotFound();
        }

        /// <summary>
        /// Gets book with specified id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Book with specified id</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /api/Book/id-{id}
        ///
        /// </remarks>
        /// <response code="200">Returns the book with specified id</response>
        /// <response code="404">If nothing found or some exception happened</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("id-{id:int}")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        { 
            var book = await _bookQueries.GetBookByIdAsync(id);

            if (book is not null)
                return Ok(book);
            else
                return NotFound();
        }

        /// <summary>
        /// Gets book with specified isbn.
        /// </summary>
        /// <param name="ISBN"></param>
        /// <returns>Book with specified isbn</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /api/Book/isbn-{isbn}
        ///
        /// </remarks>
        /// <response code="200">Returns the book with specified isbn</response>
        /// <response code="404">If nothing found or some exception happened</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("isbn-{isbn}")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetBookByISBNAsync(string ISBN)
        {
            var book = await _bookQueries.GetBookByISBNAsync(ISBN);

            if (book is not null)
                return Ok(book);
            else
                return NotFound();
        }
    }
}
