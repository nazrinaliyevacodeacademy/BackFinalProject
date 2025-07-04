using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Abstraction.Services;
using MediatR;
namespace Final.Application.Features.Commands.Users.UpdateUser
{
        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest>
        {
            private readonly IUserService _userService;

            public UpdateUserCommandHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<Unit> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
            {
                await _userService.UpdateUserAsync(request.Id, request.Dto);
                return Unit.Value;
            }

          Task IRequestHandler<UpdateUserCommandRequest>.Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
          {
            return Handle(request, cancellationToken);
          }
        }
  

}
