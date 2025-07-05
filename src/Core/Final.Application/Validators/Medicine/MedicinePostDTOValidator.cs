using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Final.Application.DTOs.Medicine;


namespace Final.Application.Validators.Medicine
{
  
        public class MedicinePostDTOValidator : AbstractValidator<MedicinePostDTO>
        {
            public MedicinePostDTOValidator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Name is required.")
                    .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

                RuleFor(x => x.Price)
                    .GreaterThan(0).WithMessage("Price must be greater than 0.");

                RuleFor(x => x.Stock)
                    .GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative.");

                RuleFor(x => x.ExpirationDate)
                    .GreaterThan(DateTime.Now).WithMessage("Expiry date must be in the future.");
            }
        }

}
