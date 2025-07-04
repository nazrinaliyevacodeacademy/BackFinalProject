using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Final.Application.Abstraction.Repositories;
using Final.Application.Abstraction.Services;
using Final.Application.DTOs.User;
using Final.Domain.Entities;

namespace Final.Persistence.Concretes.Services
{
    public class UserService : IUserService
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IMapper _mapper;

        public UserService(IUserReadRepository userReadRepository,IUserWriteRepository userWriteRepository, IMapper mapper)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _mapper = mapper;
        }
       

        public async Task CreateUserAsync(CreateUserDTO dto)
        {
            var user = _mapper.Map<User>(dto);
            await _userWriteRepository.AddAsync(user);
            await _userWriteRepository.SaveAsync();
        }

        
            /*var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return false;

            await _userRepository.DeleteAsync(user);
            await _userRepository.SaveChangesAsync();
            return true;*/
        

        /* public Task<List<UserDTO>> GetAllUsersAsync()
         {
             throw new NotImplementedException();
         }

         public Task<UserDTO> GetUserByIdAsync(Guid id)
         {
             throw new NotImplementedException();
         }*/

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _userReadRepository.GetByIdAsync(id);
            if (user == null)
                throw new Exception("User not found");

            _userWriteRepository.Delete(user);
            await _userWriteRepository.SaveAsync();
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userReadRepository.GetAllAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(Guid id)
        {
            var user = await _userReadRepository.GetByIdAsync(id);
            if (user == null)
                throw new Exception("User not found");

            return _mapper.Map<UserDTO>(user);
        }

      

        public async Task UpdateUserAsync(Guid id, UpdateUserDTO dto)
        {
            var user = await _userReadRepository.GetByIdAsync(id);
            if (user == null)
                throw new Exception("User not found");

            _mapper.Map(dto, user);
            _userWriteRepository.Update(user);
            await _userWriteRepository.SaveAsync();
        }
    }
}
