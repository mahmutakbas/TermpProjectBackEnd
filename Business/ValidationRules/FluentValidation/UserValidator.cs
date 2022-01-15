
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.name).NotNull().MaximumLength(20);
            RuleFor(u => u.surname).NotNull().MaximumLength(20);
            RuleFor(u => u.email).NotNull().EmailAddress();
        }
    }
}
