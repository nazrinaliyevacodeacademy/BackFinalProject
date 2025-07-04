using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace Final.Application.Features.Commands.Users.DeleteUser
{


    namespace Final.Application.Features.Commands.Users.DeleteUser
    {
        public class DeleteUserCommandRequest : IRequest
        {
            public Guid Id { get; set; }
        }
    }

}
