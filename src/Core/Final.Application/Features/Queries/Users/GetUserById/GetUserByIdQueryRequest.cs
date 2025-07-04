using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Final.Application.Features.Queries.Users.GetUserById
{
   public class GetUserByIdQueryRequest:IRequest<GetUserByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
