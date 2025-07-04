using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Final.Application.Features.Queries.Users.GetAllUsers
{
    public class GetAllUsersQueryRequest : IRequest<List<GetAllUsersQueryResponse>>
    {
    }
}
