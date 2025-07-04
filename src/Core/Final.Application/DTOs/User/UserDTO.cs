using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Application.DTOs.User;

public class UserDTO
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; }
    public string Role { get; set; } = null!;
   
}

