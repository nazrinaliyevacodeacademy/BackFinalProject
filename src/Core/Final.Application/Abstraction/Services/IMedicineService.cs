using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.DTOs.Medicine;

namespace Final.Application.Abstraction.Services;

public interface IMedicineService
{
    Task<MedicineGetDTO> GetMedicineByIdAsync(Guid id);
    Task<List<MedicineGetDTO>> GetAllMedicinesAsync();
    Task CreateMedicineAsync(MedicinePostDTO medicinePostDTO);
    Task UpdateMedicineAsync(Guid id, MedicinePostDTO medicinePostDTO);
    Task DeleteMedicineAsync(Guid id);

}
