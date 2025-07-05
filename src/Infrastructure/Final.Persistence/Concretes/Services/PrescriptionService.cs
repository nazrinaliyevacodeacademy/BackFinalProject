/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Abstraction.Services;
using Final.Application.DTOs.Prescription;
using Final.Domain.Entities;
using Final.Persistence.Contexts;

namespace Final.Persistence.Concretes.Services;
public class PrescriptionService : IPrescriptionService
{
    private readonly FinalDbContext _context;

    public PrescriptionService(FinalDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(CreatePrescriptionDTO dto)
    {
        var prescription = new Prescription
        {
            Id = Guid.NewGuid(),
            DoctorId = dto.DoctorId,
            PatientId = dto.PatientId,
            PrescriptionMedicines = dto.Items.Select(item => new PrescriptionMedicine
            {
                MedicineId = item.MedicineId,
                Quantity = item.Quantity
            }).ToList()
        };

        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();
    }

    public Task<List<CreatePrescriptionDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CreatePrescriptionDTO> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
*/