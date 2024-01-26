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
        /// <param name="book"></param>
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
        ///          "ReturningTime": "2023-02-02T00:00:00"
        ///    }
        ///
        /// </remarks>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If request body has incorrect values</response>
        /// <response code="401">If unauthorized request happend</response>
        /// <response code="500">If request failed due to server error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> CreateBookAsync([FromBody] BookDTO book)
        {
            try
            {
                Book? result = await _mediator.Send(new CreateBookCommand(book));

                if (result is not null)
                    return Ok(result);
                else
                    return BadRequest("Error: smth went wrong");
            }
            catch (Exception ex) when (ex is LibraryInfrastructureException ||
                                       ex is LibraryDomainException ||
                                       ex is ArgumentException)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest($"Error: {ex.ParamName} is null");
            }
            catch (DbUpdateException)
            {
                return BadRequest("Error: book with such isbn already exsists");
            }
            catch 
            {
                var result = new ObjectResult("Error: unhandled exception");
                result.StatusCode = 500;
                return result;
            }
        }

        /// <summary>
        /// Updates a book.
        /// </summary>
        /// <param name="book"></param>
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
        public async Task<IActionResult> UpdateBookAsync([FromBody] BookDTO book)
        {
            try
            {
                Book? result = await _mediator.Send(new UpdateBookCommand(book));

                if (result is not null)
                    return Ok(result);
                else
                    return BadRequest("Error: smth went wrong");
            }
            catch (Exception ex) when (ex is LibraryInfrastructureException ||
                                       ex is LibraryDomainException ||
                                       ex is ArgumentException)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest($"Error: {ex.ParamName} is null");
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Error: Invalid Id or data may have been modified or deleted since entities were loaded");
            }
            catch(DbUpdateException)
            {
                return BadRequest("Error: book with such isbn already exsists");
            }
            catch 
            {
                var result = new ObjectResult("Error: unhandled exception");
                result.StatusCode = 500;
                return result;
            }
        }

        /// <summary>
        /// Deletes a book.
        /// </summary>
        /// <param name="book"></param>
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
        public async Task<IActionResult> DelteBookAsync([FromBody] BookDTO book)
        {
            try
            {
                Book? result = await _mediator.Send(new DeleteBookCommand(book));

                if (result is not null)
                    return Ok(result);
                else
                    return BadRequest("Error: smth went wrong");
            }
            catch (Exception ex) when (ex is LibraryDomainException ||
                                       ex is ArgumentException)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest($"Error: {ex.ParamName} is null");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest("Error: Invalid Id or data may have been modified or deleted since entities were loaded");
            }
            catch
            {
                var result = new ObjectResult("Error: unhandled exception");
                result.StatusCode = 500;
                return result;
            }
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
            try 
            {
                var books = await _bookQueries.GetAllBooksAsync();

                if (books is not null)
                    return Ok(books);
                else
                    return NotFound();
            }
            catch
            {
                return NotFound();
            }
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
            try
            {
                var book = await _bookQueries.GetBookByIdAsync(id);

                if (book is not null)
                    return Ok(book);
                else
                    return NotFound();
            }
            catch
            {
                return NotFound();
            }
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
            try
            {
                var book = await _bookQueries.GetBookByISBNAsync(ISBN);

                if (book is not null)
                    return Ok(book);
                else
                    return NotFound();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
