using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.DTOs.Prescription;
using MediatR;

namespace Final.Application.Features.Commands.Prescriptions.UpdatePrescription
{
    public class UpdatePrescriptionCommandRequest :IRequest<bool>
    {
        public UpdatePrescriptionDTO Dto { get; set; }
    }
}
