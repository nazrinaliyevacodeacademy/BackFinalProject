using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Abstraction.Services;
using Final.Application.Features.Commands.Users.DeleteUser.Final.Application.Features.Commands.Users.DeleteUser;
using MediatR;
namespace Final.Application.Features.Commands.Users.DeleteUser
{
        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest>
        {
            private readonly IUserService _userService;

            public DeleteUserCommandHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<Unit> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
            {
                await _userService.DeleteUserAsync(request.Id);
                return Unit.Value;
            }

        Task IRequestHandler<DeleteUserCommandRequest>.Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
 }


