using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Final.Application.Abstraction.Repositories;

public interface IRepository<T>  where T:BaseEntity, new()
{
    DbSet<T> Table { get; }
}
