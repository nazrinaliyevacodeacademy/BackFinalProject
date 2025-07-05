using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.DTOs.Medicine;
using MediatR;

namespace Final.Application.Features.Queries.Medicines.GetAllMedicines
{
    public class GetAllMedicinesQueryRequest:IRequest<List<MedicineGetDTO>>
    {
    }
}
