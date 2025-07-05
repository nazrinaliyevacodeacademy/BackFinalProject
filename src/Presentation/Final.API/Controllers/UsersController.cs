using Final.Application.Abstraction.Services;
using Final.Application.DTOs.User;
using Final.Application.Features.Commands.Users.CreateUser;
using Final.Application.Features.Commands.Users.DeleteUser.Final.Application.Features.Commands.Users.DeleteUser;
using Final.Application.Features.Commands.Users.UpdateUser;
using Final.Application.Features.Queries.Users.GetAllUsers;
using Final.Application.Features.Queries.Users.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDTO dto)
        {
            var request = new UpdateUserCommandRequest
            {
                Id = id,
                Dto = dto
            };
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetUserByIdQueryRequest { Id = id });
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsersQueryRequest());
            return Ok(result);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteUserCommandRequest { Id = id });
            return NoContent();
        }
    }
}