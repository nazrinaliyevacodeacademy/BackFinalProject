using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.DTOs.Prescription;
using MediatR;

namespace Final.Application.Features.Commands.Prescriptions.CreatePrescription
{
    public class CreatePrescriptionCommandRequest : IRequest<CreatePrescriptionCommandResponse>
    {
        public CreatePrescriptionDTO Dto { get; set; }
    }
}
