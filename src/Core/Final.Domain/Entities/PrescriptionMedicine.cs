namespace Final.Domain.Entities;

public class PrescriptionMedicine
{
    public Guid PrescriptionId { get; set; }
    public Guid MedicineId { get; set; }
    public Prescription Prescription { get; set; }
    public Medicine Medicine { get; set;}
    public int Quantity { get; set; }
}


