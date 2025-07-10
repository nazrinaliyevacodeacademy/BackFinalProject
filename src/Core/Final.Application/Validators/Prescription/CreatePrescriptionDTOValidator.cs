using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.DTOs.Prescription;
using FluentValidation;

namespace Final.Application.Validators.Prescription;

public class CreatePrescriptionDTOValidator : AbstractValidator<CreatePrescriptionDTO>
{
    public CreatePrescriptionDTOValidator()
    {
        RuleFor(x => x.DoctorId).NotEmpty().WithMessage("Doctor ID is required.");
        RuleFor(x => x.PatientId).NotEmpty().WithMessage("Patient ID is required.");
        RuleFor(x => x.Medicines).NotEmpty().WithMessage("At least one medicine must be provided.");

        RuleForEach(x => x.Medicines).SetValidator(new PrescriptionItemDtoValidator());
    }
}
