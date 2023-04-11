using AttendanceRegister.BLL.Models;
using FluentValidation;

namespace AttendanceRegister.BLL.ModelValidators
{
    public class ClassValidator : AbstractValidator<ClassModel>
    {
        public ClassValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Назва класу не повинна бути пустою");
        }
    }
}
