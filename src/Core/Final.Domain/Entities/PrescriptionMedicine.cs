namespace Final.Domain.Entities;

public class PrescriptionMedicine
{
    public Guid PrescriptionId { get; set; }
    public Prescription Prescription { get; set; }

    public Guid MedicineId { get; set; }
    public Medicine Medicine { get; set;}
    public int Quantity { get; set; }
}


/* 
public string Code { get; set; } = null!;
  public Guid DoctorId { get; set; }
  public Guid PatientId { get; set; }
  public List<PrescriptionItem> Items { get; set; } = new();

  public User Doctor { get; set; } = null!;
  public User Patient { get; set; } = null!;
}

public class PrescriptionItem : BaseEntity
{
  public Guid PrescriptionId { get; set; }
  public Guid MedicineId { get; set; }
  public int Quantity { get; set; }

  public Medicine Medicine { get; set; } = null!;
  public Prescription Prescription { get; set; } = null!;
}*/

/*public class Medicine : BaseEntity
{
    public string Name { get; set; } = null!;
    public List<PrescriptionItem> PrescriptionItems { get; set; } = new();*/
/*}*/

/*public class User : BaseEntity
{
    public string FullName { get; set; } = null!;
    public UserRole Role { get; set; }

    public List<Prescription> DoctorPrescriptions { get; set; } = new();
    public List<Prescription> PatientPrescriptions { get; set; } = new();
}*/

/* public class Prescription
 {
 public Guid Id { get; set; }
 public string Code { get; set; } = null!;
 public Guid DoctorId { get; set; }
 public Guid PatientId { get; set; }
 public DateTime CreatedAt { get; set; }
 public List<PrescriptionItem> Items { get; set; } = new();

 public User Doctor { get; set; } = null!;
 public User Patient { get; set; } = null!;
}

public class PrescriptionItem
{
 public Guid Id { get; set; }
 public Guid PrescriptionId { get; set; }
 public Guid MedicineId { get; set; }
 public int Quantity { get; set; }

 public Medicine Medicine { get; set; } = null!;
}

public class Medicine
{
 public Guid Id { get; set; }
 public string Name { get; set; } = null!;
}

public class User
{
 public Guid Id { get; set; }
 public string FullName { get; set; } = null!;
*/

