using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Abstraction.Services;
using Final.Application.DTOs.Medicine;
using MediatR;

namespace Final.Application.Features.Commands.Medicines.CreateMedicine
{
        public class CreateMedicineCommandRequest : IRequest
        {
            public MedicinePostDTO Dto { get; set; }
        }
 }


 
