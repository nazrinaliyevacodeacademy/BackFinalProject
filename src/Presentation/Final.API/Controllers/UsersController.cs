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
   
       /* public class UsersController : ControllerBase
        {
            private readonly IUserService _userService;

            public UsersController(IUserService userService)
            {
                _userService = userService;
            }

            [HttpPost]
            public async Task<IActionResult> Create(CreateUserDTO dto)
            {
                await _userService.CreateUserAsync(dto);
                return Ok();
            }
        


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDTO dto)
    {
        await _userService.UpdateUserAsync(id, dto);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) 
                return NotFound();
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _userService.DeleteUserAsync(id);
            return NoContent();
    }*/
 

    
        public class UsersController : ControllerBase
        {
            private readonly IMediator _mediator;

            public UsersController(IMediator mediator)
            {
                _mediator = mediator;
            }

            // CREATE
            [HttpPost]
            public async Task<IActionResult> Create([FromBody] CreateUserCommandRequest request)
            {
                await _mediator.Send(request);
                return Ok();
            }

            // UPDATE
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

            // GET BY ID
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

        /*using Microsoft.AspNetCore.Authorization;
        using Microsoft.AspNetCore.Mvc;
        using Final.Application.Abstraction.Services;
        using Final.Application.DTOs.Auth;

        namespace Final.API.Controllers
        {
            [Route("api/[controller]")]
            [ApiController]
            public class AuthController : ControllerBase
            {
                private readonly IAuthService _authService;

                public AuthController(IAuthService authService)
                {
                    _authService = authService;
                }

                // ---------------- AUTH ----------------
                [HttpPost("register")]
                public async Task<IActionResult> Register(RegisterDto dto)
                {
                    var result = await _authService.RegisterAsync(dto);
                    if (!result.Success)
                        return BadRequest(result.Message);
                    return Ok(result);
                }

                [HttpPost("login")]
                public async Task<IActionResult> Login(LoginDto dto)
                {
                    var result = await _authService.LoginAsync(dto);
                    if (!result.Success)
                        return Unauthorized(result.Message);
                    return Ok(result);
                }

                // ---------------- USER CRUD ----------------
                [HttpGet("{id}")]
                [Authorize(Roles = "Admin")]
                public async Task<IActionResult> GetUserById(Guid id)
                {
                    var user = await _authService.GetByIdAsync(id);
                    return user == null ? NotFound("User not found") : Ok(user);
                }

                [HttpGet]
                [Authorize(Roles = "Admin")]
                public async Task<IActionResult> GetAllUsers()
                {
                    var users = await _authService.GetAllAsync();
                    return Ok(users);
                }

                [HttpPut("{id}")]
                [Authorize(Roles = "Admin")]
                public async Task<IActionResult> UpdateUser(Guid id, UpdateUserDto dto)
                {
                    var updated = await _authService.UpdateAsync(id, dto);
                    return updated ? Ok("User updated successfully") : NotFound("User not found");
                }

                [HttpDelete("{id}")]
                [Authorize(Roles = "Admin")]
                public async Task<IActionResult> DeleteUser(Guid id)
                {
                    var deleted = await _authService.DeleteAsync(id);
                    return deleted ? Ok("User deleted successfully") : NotFound("User not found");
                }
            }
        }
        */
    }
}





