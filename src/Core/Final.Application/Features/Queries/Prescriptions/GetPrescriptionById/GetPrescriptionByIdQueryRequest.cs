using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.DTOs.Prescription;
using MediatR;

namespace Final.Application.Features.Queries.Prescriptions.GetPrescriptionById
{
    public class GetPrescriptionByIdQueryRequest : IRequest<PrescriptionDto>
    {
        public Guid Id { get; set; }
    }
}
