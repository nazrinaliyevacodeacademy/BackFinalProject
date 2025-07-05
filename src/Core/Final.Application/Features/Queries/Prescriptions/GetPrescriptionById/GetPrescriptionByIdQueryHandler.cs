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
