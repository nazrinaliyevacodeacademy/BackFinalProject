using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Abstraction.Services;
using MediatR;

namespace Final.Application.Features.Commands.Medicines.CreateMedicine
{
    public class CreateMedicineCommandHandler : IRequestHandler<CreateMedicineCommandRequest>
    {
        private readonly IMedicineService _medicineService;

        public CreateMedicineCommandHandler(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        public async Task<Unit> Handle(CreateMedicineCommandRequest request, CancellationToken cancellationToken)
        {
            await _medicineService.CreateMedicineAsync(request.Dto);
            return Unit.Value;
        }

        Task IRequestHandler<CreateMedicineCommandRequest>.Handle(CreateMedicineCommandRequest request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }

}
