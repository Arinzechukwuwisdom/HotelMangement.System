using FluentValidation;
using HotelManagementSystem.API.Domain.DTOs;

namespace HotelManagementSystem.API.Validators
{
    public class CustomerValidator:AbstractValidator<CreateCustomerDTO>
    {
        public CustomerValidator()
        {
            RuleFor(dto => dto.EmailAddress)
               .NotEmpty().WithMessage("Email is required.")
               .EmailAddress().WithMessage("A valid email address is required.");

            RuleFor(dto => dto.PhoneNumber)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(11).WithMessage("A valid PhoneNumber is required.");

            RuleFor(dto => dto.Address)
                .NotEmpty().WithMessage("A valid Address is required.");

            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(80).WithMessage("Name cannot Exceed 80 characters.");

            RuleFor(dto => dto.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
