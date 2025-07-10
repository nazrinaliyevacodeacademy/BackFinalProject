/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Abstraction.Services;
using Final.Application.DTOs.Prescription;
using MediatR;

namespace Final.Application.Features.Queries.Prescriptions.GetPrescriptionById
{
    public class GetPrescriptionByIdQueryHandler : IRequestHandler<GetPrescriptionByIdQueryRequest, CreatePrescriptionDTO>
    {
        private readonly IPrescriptionService _prescriptionService;

        public GetPrescriptionByIdQueryHandler(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        public async Task<CreatePrescriptionDTO> Handle(GetPrescriptionByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await _prescriptionService.GetByIdAsync(request.Id);
        }
    }

}*/
/*using MediatR;
using Final.Application.Abstraction.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Final.Application.DTOs.Prescription;

public class GetPrescriptionByIdQueryHandler : IRequestHandler<GetPrescriptionByIdQuery, PrescriptionDto>
{
    private readonly IPrescriptionReadRepository _readRepository;
    private readonly IMapper _mapper;

    public GetPrescriptionByIdQueryHandler(IPrescriptionReadRepository readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<PrescriptionDto> Handle(GetPrescriptionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _readRepository.Table
            .Include(p => p.PrescriptionMedicines)
            .FirstOrDefaultAsync(p => p.Id == request.Id);

        if (entity == null) return null;

        var dto = new PrescriptionDto
        {
            Id = entity.Id,
            PatientId = entity.PatientId,
            DoctorId = entity.DoctorId,
            CreatedDate = entity.CreatedDate,
            Medicines = entity.PrescriptionMedicines.Select(pm => new PrescriptionItemDto
            {
                MedicineId = pm.MedicineId,
                Quantity = pm.Quantity
            }).ToList()
        };

        return dto;
    }
}
*/using Final.Application.Abstraction.Services;
using Final.Application.DTOs.Prescription;
using Final.Application.Features.Queries.Prescriptions.GetPrescriptionById;
using MediatR;

namespace Final.Application.Features.Prescriptions.Queries.GetById
{
    public class GetPrescriptionByIdQueryHandler : IRequestHandler<GetPrescriptionByIdQueryRequest, PrescriptionDto>
    {
        private readonly IPrescriptionService _service;

        public GetPrescriptionByIdQueryHandler(IPrescriptionService service)
        {
            _service = service;
        }

        public async Task<PrescriptionDto?> Handle(GetPrescriptionByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.GetByIdAsync(request.Id);
        }
    }
}

