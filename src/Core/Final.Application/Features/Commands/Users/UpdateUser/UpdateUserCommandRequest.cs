using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.DTOs.User;
using MediatR;
namespace Final.Application.Features.Commands.Users.UpdateUser
{
        public class UpdateUserCommandRequest : IRequest
        {
            public Guid Id { get; set; }
            public UpdateUserDTO Dto { get; set; } = null!;
        }
 }


