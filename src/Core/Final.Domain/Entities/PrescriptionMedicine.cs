using Final.Domain.Entities.Common;

namespace Final.Domain.Entities;

public class PrescriptionMedicine:BaseEntity
{
    public Guid PrescriptionId { get; set; }
    public Guid MedicineId { get; set; }
    public Prescription Prescription { get; set; }
    public Medicine Medicine { get; set;}
    public int Quantity { get; set; }
}


