using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Abstraction.Repositories;
using Final.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Final.Application.Features.Commands.Prescriptions.UpdatePrescription
{
    public class UpdatePrescriptionCommandHandler : IRequestHandler<UpdatePrescriptionCommandRequest, bool>
    {
        private readonly IPrescriptionReadRepository _readRepository;
        private readonly IPrescriptionWriteRepository _writeRepository;

        public UpdatePrescriptionCommandHandler(IPrescriptionReadRepository readRepository, IPrescriptionWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<bool> Handle(UpdatePrescriptionCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            var entity = await _readRepository.Table
                .Include(p => p.PrescriptionMedicines)
                .FirstOrDefaultAsync(p => p.Id == dto.Id, cancellationToken);

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
    }
}

