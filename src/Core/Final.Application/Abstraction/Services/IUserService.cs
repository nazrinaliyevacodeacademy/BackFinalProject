using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.DTOs.User;

namespace Final.Application.Abstraction.Services
{
    public interface IUserService
    {
     Task<UserDTO> GetUserByIdAsync(Guid id);
     Task<List<UserDTO>> GetAllUsersAsync();
     Task CreateUserAsync(CreateUserDTO dto);
     Task UpdateUserAsync(Guid id, UpdateUserDTO dto);
     Task DeleteUserAsync(Guid id);
        

    }
}
