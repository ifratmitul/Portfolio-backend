using FluentValidation;
namespace Application.Schools;
public class EducationValidator : AbstractValidator<Education>
{
    public EducationValidator()
    {
        RuleFor(x => x.Institution).NotEmpty().NotNull();
        RuleFor(x => x.Degree).NotEmpty().NotNull();
        RuleFor(x => x.Result).NotEmpty().NotNull();
        RuleFor(x => x.StartDate).NotNull();
        RuleFor(x => x.EndDate).NotNull().GreaterThan(x => x.StartDate);
        RuleFor(x => x.Major).NotEmpty().NotNull();

    }
}
