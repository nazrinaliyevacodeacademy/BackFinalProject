using Final.Application.Abstraction.Repositories;
using Final.Application.Features.Commands.Prescriptions.CreatePrescription;
using Final.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class CreatePrescriptionCommandHandler : IRequestHandler<CreatePrescriptionCommandRequest, CreatePrescriptionCommandResponse>
{
    private readonly IPrescriptionWriteRepository _prescriptionWriteRepository;
    private readonly IMedicineReadRepository _medicineReadRepository;

    public CreatePrescriptionCommandHandler(IPrescriptionWriteRepository prescriptionWriteRepository, IMedicineReadRepository medicineReadRepository)
    {
        _prescriptionWriteRepository = prescriptionWriteRepository;
        _medicineReadRepository = medicineReadRepository;
    }

    public async Task<CreatePrescriptionCommandResponse> Handle(CreatePrescriptionCommandRequest request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        // 3.1 — Dərmanların mövcudluğunu yoxla
        foreach (var medicine in dto.Medicines)
        {
            bool exists = await _medicineReadRepository.Table
                .AnyAsync(m => m.Id == medicine.MedicineId, cancellationToken);

            if (!exists)
            {
                return new CreatePrescriptionCommandResponse
                {
                    Success = false,
                    Message = $"Medicine with ID {medicine.MedicineId} not found."
                };
            }
        }

        var prescription = new Prescription
        {
            Id = Guid.NewGuid(),
            PatientId = dto.PatientId,
            DoctorId = dto.DoctorId,
            IssuedAt = DateTime.UtcNow, // Sənin entity-də CreatedDate yoxdu, IssuedAt istifadə et
            PrescriptionMedicines = dto.Medicines.Select(m => new PrescriptionMedicine
            {
                MedicineId = m.MedicineId,
                Quantity = m.Quantity
            }).ToList()
        };

        await _prescriptionWriteRepository.CreateAsync(prescription);
      

        return new CreatePrescriptionCommandResponse
        {
            Success = true,
            Message = "Prescription created successfully",
            PrescriptionId = prescription.Id
        };
    }
}
