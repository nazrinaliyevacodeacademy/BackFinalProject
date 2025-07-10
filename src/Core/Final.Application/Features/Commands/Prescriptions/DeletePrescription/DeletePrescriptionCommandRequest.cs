using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Final.Application.Features.Commands.Prescriptions.DeletePrescription
{
    public class DeletePrescriptionCommandRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
