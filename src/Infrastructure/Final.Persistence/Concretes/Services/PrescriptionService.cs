using Final.Application.Abstraction.Repositories;
using Final.Application.Abstraction.Services;
using Final.Application.DTOs.Prescription;
using Final.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Final.Persistence.Concretes.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionReadRepository _readRepository;
        private readonly IPrescriptionWriteRepository _writeRepository;

        public PrescriptionService(IPrescriptionReadRepository readRepository, IPrescriptionWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<Guid?> CreateAsync(CreatePrescriptionDTO dto)
        {
            var prescription = new Prescription
            {
                Id = Guid.NewGuid(),
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                IssuedAt = DateTime.UtcNow,
                PrescriptionMedicines = dto.Medicines.Select(m => new PrescriptionMedicine
                {
                    MedicineId = m.MedicineId,
                    Quantity = m.Quantity
                }).ToList()
            };

            await _writeRepository.CreateAsync(prescription);
            return prescription.Id;
        }

        public async Task<List<PrescriptionDto>> GetAllAsync()
        {
            var list = await _readRepository.Table
                .Include(p => p.PrescriptionMedicines)
                .ThenInclude(pm => pm.Medicine)
                .ToListAsync();

            return list.Select(p => new PrescriptionDto
            {
                Id = p.Id,
                PatientId = p.PatientId,
                DoctorId = p.DoctorId,
               /* CreatedDate = p.CreatedDate,*/
                Medicines = p.PrescriptionMedicines.Select(pm => new PrescriptionItemDto
                {
                    MedicineId = pm.MedicineId,
                    Quantity = pm.Quantity
                }).ToList()
            }).ToList();
        }

        public async Task<PrescriptionDto?> GetByIdAsync(Guid id)
        {
            var entity = await _readRepository.Table
                .Include(p => p.PrescriptionMedicines)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (entity is null) return null;

            return new PrescriptionDto
            {
                Id = entity.Id,
                PatientId = entity.PatientId,
                DoctorId = entity.DoctorId,
               /* CreatedDate = entity.CreatedDate,*/
                Medicines = entity.PrescriptionMedicines.Select(pm => new PrescriptionItemDto
                {
                    MedicineId = pm.MedicineId,
                    Quantity = pm.Quantity
                }).ToList()
            };
        }

        public async Task<bool> UpdateAsync(UpdatePrescriptionDTO dto)
        {
            var entity = await _readRepository.Table
                .Include(p => p.PrescriptionMedicines)
                .FirstOrDefaultAsync(p => p.Id == dto.Id);

            if (entity is null) return false;

            entity.DoctorId = dto.DoctorId;
            entity.PatientId = dto.PatientId;
            entity.PrescriptionMedicines = dto.Medicines.Select(m => new PrescriptionMedicine
            {
                MedicineId = m.MedicineId,
                Quantity = m.Quantity
            }).ToList();

            await _writeRepository.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _writeRepository.DeleteAsync(id);
            return true;
        }

        Task<Guid> IPrescriptionService.CreateAsync(CreatePrescriptionDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
