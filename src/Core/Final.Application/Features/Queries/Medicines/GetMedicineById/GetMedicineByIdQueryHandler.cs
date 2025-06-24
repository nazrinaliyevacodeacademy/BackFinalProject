using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Abstraction.Services;
using Final.Application.DTOs.Medicine;
using MediatR;

namespace Final.Application.Features.Queries.Medicines.GetMedicineById;

public class GetMedicineByIdQueryHandler : IRequestHandler<GetMedicineByIdQueryRequest, GetMedicineByIdQueryResponse>
{
    private readonly IMedicineService _service;

    public GetMedicineByIdQueryHandler(IMedicineService service)
    {
        _service = service;
    }

    public async Task<GetMedicineByIdQueryResponse> Handle(GetMedicineByIdQueryRequest request, CancellationToken cancellationToken)
    {
      MedicineGetDTO medicineGetDTO= await _service.GetMedicineByIdAsync(request.Id,request.IsTracking);
        GetMedicineByIdQueryResponse response = new()
        {
            MedicineGetDTO = medicineGetDTO,
            statusCode = (int)HttpStatusCode.OK
        };
        return response;    
    }
}
