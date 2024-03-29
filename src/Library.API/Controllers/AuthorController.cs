﻿using Library.Application.Authors.Commands.CreateAuthorCommand;
using Library.Application.Authors.Commands.DeleteAuthorCommand;
using Library.Application.Authors.Commands.UpdateAuthorCommand;
using Library.Application.Authors.Queries.GetAuthorById;
using Library.Application.Authors.Queries.GetPaginatedAuthors;
using Library.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates an author.
        /// </summary>
        /// <param name="createAuthorCommand"></param>
        /// <returns>A created author</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/author/
        ///     {
        ///         "name": "Ivanov Ivan",
        ///     }
        ///
        /// </remarks>
        /// <response code="200"> If creation was succesfull</response>
        /// <response code="400"> If request body has incorrect values</response>
        /// <response code="401"> If unauthorized request happend</response>
        /// <response code="500"> If request failed due to server error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAuthorAsync([FromBody] CreateAuthorCommand createAuthorCommand)
        {
            AuthorDTO author = await _mediator.Send(createAuthorCommand);

            return Ok(author);
        }

        /// <summary>
        /// Updates an author.
        /// </summary>
        /// <param name="updateAuthorCommand"></param>
        /// <returns>A updated author</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /api/author/
        ///     {
        ///         "id": 4
        ///         "name": "Ivanov Ivan",
        ///     }
        ///
        /// </remarks>
        /// <response code="200"> If updation was succesfull</response>
        /// <response code="400"> If request body has incorrect values</response>
        /// <response code="401"> If unauthorized request happend</response>
        /// <response code="404"> If entity wasnt found</response>
        /// <response code="500"> If request failed due to server error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateAuthorAsync([FromBody] UpdateAuthorCommand updateAuthorCommand)
        {
            AuthorDTO author = await _mediator.Send(updateAuthorCommand);

            return Ok(author);
        }

        /// <summary>
        /// Deletes an author.
        /// </summary>
        /// <param name="deleteAuthorCommand"></param>
        /// <returns>A deleted author</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Delete /api/author/
        ///     {
        ///         "id": 4
        ///     
        ///     }
        ///
        /// </remarks>
        /// <response code="200"> If deletion was succesfull</response>
        /// <response code="400"> If request body has incorrect values</response>
        /// <response code="401"> If unauthorized request happend</response>
        /// <response code="404"> If entity wasnt found</response>
        /// <response code="500"> If request failed due to server error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteAuthorAsync([FromBody] DeleteAuthorCommand deleteAuthorCommand)
        {
            await _mediator.Send(deleteAuthorCommand);

            return Ok();
        }

        /// <summary>
        /// Gets an author.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An author with it's books</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /api/author/4
        ///     
        ///    
        ///         
        ///     
        ///
        /// </remarks>
        /// <response code="200"> If get was succesfull</response>
        /// <response code="404"> If entity wasnt found</response>
        /// <response code="500"> If request failed due to server error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetAuthor(int id)
        {
            AuthorDTO result = await _mediator.Send(new GetAuthorByIdQuery(id));

            return Ok(result);
        }

        /// <summary>
        /// Gets a paginated authors.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>Collectoin of authors, current page and total pages</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /api/author?pageNumber=1&pageSize=3
        ///     
        ///    
        ///         
        ///     
        ///
        /// </remarks>
        /// <response code="200"> If get was succesfull</response>
        /// <response code="404"> If entities wasnt found</response>
        /// <response code="500"> If request failed due to server error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetPaginatedAuthors([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 3)
        {
            PaginatedResult<AuthorDTO> result = await _mediator.Send(new GetPaginatedAuthorsQuery(pageNumber, pageSize));

            return Ok(result);
        }
    }
}
