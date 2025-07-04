using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Final.Application.Abstraction.Services;
using Final.Application.DTOs.User;
using global::Final.Domain.Enums;
using MediatR;
namespace Final.Application.Features.Commands.Users.CreateUser
{

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest>
        {
            private readonly IUserService _userService;
            private readonly IMapper _mapper;

            public CreateUserCommandHandler(IUserService userService, IMapper mapper)
            {
                _userService = userService;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
            {
                var dto = new CreateUserDTO
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    Password = request.Password,
                    Role = Enum.TryParse<UserRole>(request.Role, true, out var parsedRole) ? parsedRole : UserRole.Patient
                };

                await _userService.CreateUserAsync(dto);
                return Unit.Value;
            }

         Task IRequestHandler<CreateUserCommandRequest>.Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
 }


