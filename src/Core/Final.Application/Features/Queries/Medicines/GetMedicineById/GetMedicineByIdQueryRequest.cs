using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Final.Application.Features.Queries.Medicines.GetMedicineById;
public class GetMedicineByIdQueryRequest:IRequest<GetMedicineByIdQueryResponse>
{
   public  Guid Id { get; set; }   
public bool IsTracking {  get; set; }   
 
}
