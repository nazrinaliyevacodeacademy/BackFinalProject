using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace Final.Application.Features.Commands.Users.CreateUser
{
        public class CreateUserCommandRequest : IRequest
        {
            public string UserName { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string Password { get; set; } = null!;
            public string Role { get; set; } = "Patient";
        }
}


