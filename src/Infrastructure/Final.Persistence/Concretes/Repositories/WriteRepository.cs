using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Umbraco.Core.Persistence;

namespace Final.Persistence.Concretes.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
    {
        protected readonly FinalDbContext _context;
        public WriteRepository(FinalDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();
        public void Save(T entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }


        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

    
        public async Task UpdateAsync(T entity)
        {
            Table.Update(entity);
            await _context.SaveChangesAsync();
        }

        /*  

          public Task UpdateAsync(T entity)
          {
              Table.Update(entity);
              return Task.CompletedTask;
          }*/
        
      
        public async Task DeleteAsync(Guid id)
        {
            var entity = await Table.FindAsync(id);
            if (entity is not null)
            {
                Table.Remove(entity);
                await _context.SaveChangesAsync(); 
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
