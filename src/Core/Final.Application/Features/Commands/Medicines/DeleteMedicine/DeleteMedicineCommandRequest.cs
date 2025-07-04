using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Final.Application.Features.Commands.Medicines.DeleteMedicine
{
    public class DeleteMedicineCommandRequest : IRequest
    {
        public Guid Id { get; set; }
    }

}
