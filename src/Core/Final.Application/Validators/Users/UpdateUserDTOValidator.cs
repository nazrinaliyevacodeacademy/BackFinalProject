using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.DTOs.User;
using FluentValidation;


namespace Final.Application.Validators.Users
{
    public class UpdateUserDTOValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserDTOValidator()
        {
            RuleFor(x => x.UserName)
                .MinimumLength(3).When(x => !string.IsNullOrWhiteSpace(x.UserName))
                .WithMessage("Username must be at least 3 characters long.");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email))
                .WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .MinimumLength(6).When(x => !string.IsNullOrWhiteSpace(x.Password))
                .WithMessage("Password must be at least 6 characters long.");

            RuleFor(x => x.Role)
                .IsInEnum().When(x => x.Role.HasValue)
                .WithMessage("Invalid user role.");
        }
    }
}

       
