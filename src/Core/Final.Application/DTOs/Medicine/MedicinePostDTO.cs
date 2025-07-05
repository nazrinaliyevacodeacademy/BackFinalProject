using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Final.Application.DTOs.Medicine;

public class MedicinePostDTO
{
    public string Name { get; set; } = null!;
    public string Manufacturer { get; set; } =null!;
    public float Price { get; set; }
    public int Stock { get; set; }
    public string Dosage { get; set; }
    public string Category { get; set; }
    public DateTime ExpirationDate { get; set; }
    public IFormFile Image { get; set; } = null!;
    public string? ImageUrl { get; set; }
}
