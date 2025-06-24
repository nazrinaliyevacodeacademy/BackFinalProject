using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Domain.Entities.Common;

namespace Final.Application.Abstraction.Repositories
{
    public interface IReadRepository<T>: IRepository<T> where T : BaseEntity, new()
    {
        Task<T> GetByIdAsync(Guid id,bool isTracking=false);
    }
}
