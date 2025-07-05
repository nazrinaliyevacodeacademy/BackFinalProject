using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Domain.Entities.Common;
using Final.Domain.Enums;

namespace Final.Domain.Entities;
public class Prescription : BaseEntity
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public DateTime IssuedAt { get; set; }

    public User Patient { get; set; }
    public User Doctor { get; set; }

    public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicine>();
}

