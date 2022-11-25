using FluentValidation;
using FluentValidationDemo.Models;

namespace FluentValidationDemo.validators
{
    public class Customervalidator: AbstractValidator<Customer>
    {
        public Customervalidator()
        {

            
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Lastname cannot be empty")
                .Length(3, 20).WithMessage("Lastname must be between 3 - 20 characters");
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Firtname cannot be empty")
                .Length(3,20)
                .WithMessage("Firstname must be between 3 - 20 characters");

        }

    }
}
