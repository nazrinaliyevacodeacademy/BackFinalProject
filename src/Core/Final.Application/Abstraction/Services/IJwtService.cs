using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Domain.Entities;

namespace Final.Application.Abstraction.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
