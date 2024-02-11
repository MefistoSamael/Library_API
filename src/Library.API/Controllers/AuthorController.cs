using Library.API.Application.Authors.Commands.CreateAuthorCommand;
using Library.API.Application.Authors.Commands.DeleteAuthorCommand;
using Library.API.Application.Authors.Commands.UpdateAuthorCommand;
using Library.API.Application.Authors.Queries.GetAllAuthors;
using Library.API.Application.Common;
using Library.Domain.Models.AuthorModel;
using MediatR;
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

        [HttpPost]
        public async Task<IActionResult> CreateAuthorAsync([FromBody] CreateAuthorCommand createAuthorCommand)
        {
            AuthorDTO author = await _mediator.Send(createAuthorCommand);

            return Ok(author);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthorAsync([FromBody] UpdateAuthorCommand updateAuthorCommand)
        {
            AuthorDTO author = await _mediator.Send(updateAuthorCommand);

            return Ok(author);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAuthorAsync([FromBody] DeleteAuthorCommand deleteAuthorCommand)
        {
            await _mediator.Send(deleteAuthorCommand);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            IEnumerable<AuthorDTO> result = await _mediator.Send(new GetAllAuthorsQuery());

            return Ok(result);    
        }

        [HttpGet]
        [Route("id-{id:int}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("pageNumber-{pageNumber:int}/pageSize-{pageSize:int}")]
        public async Task<IActionResult> GetPaginatedAuthors()
        {
            var result = await _mediator.Send(new GetAllAuthorsQuery());
            return Ok(result);
        }
    }
}
