using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.DTOs.Medicine;

namespace Final.Application.Features.Queries.Medicines.GetMedicineById;

public class GetMedicineByIdQueryResponse
{
   public MedicineGetDTO MedicineGetDTO { get; set; } 
   public int statusCode { get; set; }  
}
