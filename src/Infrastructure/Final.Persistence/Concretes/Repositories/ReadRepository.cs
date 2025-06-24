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
        private readonly FinalDbContext _context;
        public ReadRepository(FinalDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();
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
    }

  
}
