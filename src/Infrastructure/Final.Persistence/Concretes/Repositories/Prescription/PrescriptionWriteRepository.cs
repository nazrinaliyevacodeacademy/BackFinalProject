using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Abstraction.Repositories;
using Final.Domain.Entities;
namespace Final.Persistence.Concretes.Repositories;

public class PrescriptionWriteRepository : WriteRepository<Prescription>, IPrescriptionWriteRepository
{
    public PrescriptionWriteRepository(FinalDbContext context) : base(context)
    {
    }
}
