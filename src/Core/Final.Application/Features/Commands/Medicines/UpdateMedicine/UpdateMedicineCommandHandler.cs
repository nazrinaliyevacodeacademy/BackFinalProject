using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Abstraction.Services;
using MediatR;

namespace Final.Application.Features.Commands.Medicines.UpdateMedicine
{
 
        public class UpdateMedicineCommandHandler : IRequestHandler<UpdateMedicineCommandRequest>
        {
            private readonly IMedicineService _medicineService;

            public UpdateMedicineCommandHandler(IMedicineService medicineService)
            {
                _medicineService = medicineService;
            }

            public async Task<Unit> Handle(UpdateMedicineCommandRequest request, CancellationToken cancellationToken)
            {
                await _medicineService.UpdateMedicineAsync(request.Id, request.Dto);
                return Unit.Value;
            }

        Task IRequestHandler<UpdateMedicineCommandRequest>.Handle(UpdateMedicineCommandRequest request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
    }


