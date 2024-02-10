using Library.API.Application.Authors.Commands.CreateAuthorCommand;
using Library.API.Application.Authors.Commands.DeleteAuthorCommand;
using Library.API.Application.Authors.Queries.GetAllAuthors;
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
            Author author = await _mediator.Send(createAuthorCommand);

            return Ok(author);
        }

        public async Task<IActionResult> UpdateAuthorAsync()
        {
            throw new NotImplementedException();
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
            var result = await _mediator.Send(new GetAllAuthorsQuery());
            return Ok(result);    
        }

        public async Task<IActionResult> GetAuthor(int id)
        {
            throw new NotImplementedException();
        }
    }
}
