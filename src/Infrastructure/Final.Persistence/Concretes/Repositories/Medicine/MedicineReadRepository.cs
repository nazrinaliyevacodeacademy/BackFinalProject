using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Domain.Entities;


using Final.Persistence.Contexts;
using Final.Application.Abstraction.Repositories;

namespace Final.Persistence.Concretes.Repositories;
public class MedicineReadRepository : ReadRepository<Medicine>, IMedicineReadRepository
{
    public MedicineReadRepository(FinalDbContext context) : base(context)
    {
    }
}

