using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Final.Application.Abstraction.Services;
using MediatR;

/*namespace Final.Application.Features.Queries.Users.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
    {
        public Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}*/


namespace Final.Application.Features.Queries.Users.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var userDto = await _userService.GetUserByIdAsync(request.Id);
            return new GetUserByIdQueryResponse
            {
                Id = userDto.Id,
                UserName = userDto.UserName,
                Email = userDto.Email,
                Role = userDto.Role
            };
        }
    }
}
