using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Application.DTOs.Prescription
{
    public class PrescriptionDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<PrescriptionItemDto> Medicines { get; set; }
    }
}
