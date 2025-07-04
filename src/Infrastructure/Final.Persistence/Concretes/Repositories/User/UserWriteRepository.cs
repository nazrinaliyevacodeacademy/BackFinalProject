using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Abstraction.Repositories;
using Final.Domain.Entities;
using Final.Persistence.Contexts;


namespace Final.Persistence.Concretes.Repositories
{
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(FinalDbContext context) : base(context) { }
        public async Task ChangePasswordAsync(Guid userId, string newPasswordHash)
        {
            var user = await Table.FindAsync(userId);
            if (user is not null)
            {
                user.PasswordHash = newPasswordHash;
            }
        }

        public async Task AddAsync(User user)
        {
            await Table.AddAsync(user);
        }

        public void Update(User user)
        {
            Table.Update(user);
        }

        public void Delete(User user)
        {
            Table.Remove(user);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

