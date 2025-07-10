using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Abstraction.Services;
using Final.Application.DTOs.Prescription;
using MediatR;

namespace Final.Application.Features.Queries.Prescriptions.GetAllPrescriptions
{
    public class GetAllPrescriptionsQueryHandler : IRequestHandler<GetAllPrescriptionsQueryRequest, List<PrescriptionDto>>
    {
        private readonly IPrescriptionService _prescriptionService;

        public GetAllPrescriptionsQueryHandler(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        public async Task<List<PrescriptionDto>> Handle(GetAllPrescriptionsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _prescriptionService.GetAllAsync();
        }
    }

}
