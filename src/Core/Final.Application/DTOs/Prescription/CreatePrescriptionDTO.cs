using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Application.DTOs.Prescription;
public class CreatePrescriptionDTO
{

    public Guid DoctorId { get; set; }
    public Guid PatientId { get; set; }
    public List<PrescriptionItemDto> Items { get; set; } = new();

}
public class PrescriptionItemDto
{
    public Guid MedicineId { get; set; }
    public int Quantity { get; set; }
}


