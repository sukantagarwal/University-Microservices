using FluentValidation;

namespace University.Cources.Application.Commands.Validators
{
    public class AddCourseCommandValidator: AbstractValidator<AddCourseCommand>
    {
        public AddCourseCommandValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty();
            RuleFor(x => x.Credits).GreaterThan(0);
            RuleFor(x => x.DepartmentId).NotNull();
        }
    }
}