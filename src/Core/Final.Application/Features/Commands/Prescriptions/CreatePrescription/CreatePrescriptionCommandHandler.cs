using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Domain.Entities;
using MediatR;

/*namespace Final.Application.Features.Commands.Prescriptions.CreatePrescription
{
    public class CreatePrescriptionCommandHandler : IRequestHandler<CreatePrescriptionCommandRequest>
    {
        private readonly FinalDbContext _context;

        public CreatePrescriptionCommandHandler(FinalDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreatePrescriptionCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

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

            return Unit.Value;
        }

        Task IRequestHandler<CreatePrescriptionCommandRequest>.Handle(CreatePrescriptionCommandRequest request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }

}
*/