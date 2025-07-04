using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Final.Application.DTOs.Medicine;

public class MedicineGetDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Manufacturer { get; set; } 
    public float Price { get; set; }
    public int Stock { get; set; }
    public string Dosage { get; set; }
    public string Category { get; set; }
    public DateTime ExpirationDate { get; set; }



    


}
