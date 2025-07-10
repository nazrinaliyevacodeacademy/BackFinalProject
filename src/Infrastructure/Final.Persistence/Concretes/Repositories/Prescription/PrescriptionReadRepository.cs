using Final.Application.Abstraction.Repositories;
using Final.Domain.Entities;

namespace Final.Persistence.Concretes.Repositories;

public class PrescriptionReadRepository : ReadRepository<Prescription>, IPrescriptionReadRepository
{
    public PrescriptionReadRepository(FinalDbContext context) : base(context)
    {
    }
}