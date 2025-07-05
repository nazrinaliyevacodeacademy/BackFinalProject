using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Domain.Entities.Common;

namespace Final.Domain.Entities;

public  class Medicine:BaseEntity
{

    public string Name { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string ImageUrl { get; set; }= null!;
    public float Price { get; set; }
    public int Stock { get; set; }
    public string Dosage { get; set; } = null!;
    public string Category { get; set; } = null!;   
    public DateTime ExpirationDate { get; set; }


    // Навигационные свойства
    public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicine>();
    /*  public ICollection<Prescription> Prescriptions { get; set; }=new List<Prescription>();   */
}


