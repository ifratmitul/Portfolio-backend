using FluentValidation;


namespace Application.Validations
{
    public class ExperienceValidator : AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            //RuleFor(e => e.Company).NotEmpty().NotNull();
            //RuleFor(e => e.Position).NotEmpty().NotNull();
            //RuleFor(e => e.Logo).NotEmpty().NotNull();
            //RuleFor(e => e.StartDate).NotEmpty().NotNull();
            //RuleFor(e => e.EndDate).GreaterThan(e => e.StartDate).Null();
        }
    }
}
