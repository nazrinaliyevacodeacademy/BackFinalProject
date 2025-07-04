using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Domain.Enums;

namespace Final.Application.DTOs.User
{
    public class CreateUserDTO
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public UserRole? Role { get; set; } = UserRole.Patient;
    }

}

