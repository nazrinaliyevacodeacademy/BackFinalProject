using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Abstraction.Services;
using MediatR;

namespace Final.Application.Features.Commands.Medicines.DeleteMedicine
{
        public class DeleteMedicineCommandHandler : IRequestHandler<DeleteMedicineCommandRequest>
        {
            private readonly IMedicineService _medicineService;

            public DeleteMedicineCommandHandler(IMedicineService medicineService)
            {
                _medicineService = medicineService;
            }

            public async Task<Unit> Handle(DeleteMedicineCommandRequest request, CancellationToken cancellationToken)
            {
                await _medicineService.DeleteMedicineAsync(request.Id);
                return Unit.Value;
            }

        Task IRequestHandler<DeleteMedicineCommandRequest>.Handle(DeleteMedicineCommandRequest request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    
         }

}
