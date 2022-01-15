using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<RouteOfUser>
    {
        public BrandValidator()
        {
            //RuleFor(b => b.BrandName).NotEmpty();
            //RuleFor(b => b.BrandName).MinimumLength(2);
        }
    }
}
