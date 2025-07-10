using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.DTOs.Prescription;
using FluentValidation;

namespace Final.Application.Validators.Prescription;

public class PrescriptionItemDtoValidator:AbstractValidator<PrescriptionItemDto>
 {
  public PrescriptionItemDtoValidator()
  { 
    RuleFor(x => x.MedicineId).NotEmpty().WithMessage("Medicine ID is required.");
    RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
  }
}
