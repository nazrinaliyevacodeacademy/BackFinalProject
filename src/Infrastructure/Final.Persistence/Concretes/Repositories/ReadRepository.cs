using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Final.Domain.Entities.Common;
using Umbraco.Core.Persistence;
using Final.Persistence.Contexts;
using Final.Application.Abstraction.Repositories;

namespace Final.Persistence.Concretes.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
    {
        protected readonly FinalDbContext _context;
        public ReadRepository(FinalDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<List<T>> GetAllAsync(bool isTracking = false)
        {
            var query = Table.AsQueryable();

            if (!isTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id, bool isTracking = false)
        {
            var query = Table.AsQueryable();
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            T? entity = await query.SingleOrDefaultAsync(t => t.Id == id);
            return entity;
        }

        /* public DbSet<User> Table => _context.Set<User>();*/

        /*public async Task<T?> GetByEmailAsync(string email, bool isTracking = false)
        {
            IQueryable<T> query = Table;
            if (!isTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(u => u.Email == email);
        }*/

        /*  public async Task<User?> GetByIdAsync(Guid id, bool isTracking = false)
          {
              IQueryable<User> query = Table;
              if (!isTracking)
                  query = query.AsNoTracking();

              return await query.FirstOrDefaultAsync(u => u.Id == id);*/
    }
}



