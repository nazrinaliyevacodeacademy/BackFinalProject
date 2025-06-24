using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Final.Application.DTOs.Medicine;

namespace Final.Application.Abstraction.Services;

public interface IMedicineService
{
    Task<MedicineGetDTO> GetMedicineByIdAsync(Guid id,bool isTracking=false);
    Task CreateMedicineAsync(MedicinePostDTO medicinePostDTO);
}
