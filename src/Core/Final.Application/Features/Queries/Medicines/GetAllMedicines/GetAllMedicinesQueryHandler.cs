using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Abstraction.Services;
using Final.Application.DTOs.Medicine;
using MediatR;

namespace Final.Application.Features.Queries.Medicines.GetAllMedicines
{
    public class GetAllMedicinesQueryHandler : IRequestHandler<GetAllMedicinesQueryRequest, List<MedicineGetDTO>>
    {
        private readonly IMedicineService _medicineService;

        public GetAllMedicinesQueryHandler(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        public async Task<List<MedicineGetDTO>> Handle(GetAllMedicinesQueryRequest request, CancellationToken cancellationToken)
        {
            return await _medicineService.GetAllMedicinesAsync();
        }
    }
}
