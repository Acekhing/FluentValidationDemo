using FluentValidation;
using FluentValidationDemo.Models;

namespace FluentValidationDemo.validators
{
    public class Customervalidator: AbstractValidator<Customer>
    {
        public Customervalidator()
        {
            RuleFor(x => x.LastName).NotEmpty().Length(3, 20).WithMessage("Lastname must not be empty and between 3 - 20 characters");
            RuleFor(x => x.FirstName).NotEmpty().Length(3,20).WithMessage("Firstname must not be empty and between 3 - 20 characters");
          

        }

    }
}
