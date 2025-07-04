using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Abstraction.Repositories;
using Final.Domain.Entities;
using Final.Persistence.Concretes.Repositories;
using Final.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Final.Persistence.Concretes.Repositories
{
    /*
   

            public DbSet<User> Table => _context.Set<User>();

            public async Task<User?> GetByEmailAsync(string email, bool isTracking = false)
            {
                IQueryable<User> query = Table;
                if (!isTracking)
                    query = query.AsNoTracking();

                return await query.FirstOrDefaultAsync(u => u.Email == email);
            }
    */
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(FinalDbContext context) : base(context) { }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await Table.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User?> GetByIdAsync(Guid id, bool isTracking = false)
        {
            IQueryable<User> query = Table;
            if (!isTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}

