using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Final.Application.Abstraction.Repositories;
public interface IPrescriptionReadRepository : IReadRepository<Prescription>
{

}


