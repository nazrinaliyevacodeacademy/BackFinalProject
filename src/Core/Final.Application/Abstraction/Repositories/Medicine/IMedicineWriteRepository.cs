using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Domain.Entities;

namespace Final.Application.Abstraction.Repositories;

public interface IMedicineWriteRepository : IWriteRepository<Medicine>
{
   
    void Delete(Medicine medicine);
  
 
}
