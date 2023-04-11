using AttendanceRegister.BLL.Models;
using FluentValidation;

namespace AttendanceRegister.BLL.ModelValidators
{
    public class SubjectValidator : AbstractValidator<SubjectModel>
    {
        public SubjectValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Назва предмету не повинна бути пустою");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Назва предмету повинна містити мінімум 3 літери");
        }
    }
}
