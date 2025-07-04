using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Domain.Entities;

namespace Final.Application.Abstraction.Repositories
{
    public interface IUserWriteRepository:IWriteRepository<User>
    {
        Task AddAsync(User user);
        Task ChangePasswordAsync(Guid userId, string newPasswordHash);
        void Delete(User user);
        Task SaveAsync();
        void Update(User user);
    }
}
