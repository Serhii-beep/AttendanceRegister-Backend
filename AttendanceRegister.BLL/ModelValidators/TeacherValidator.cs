using AttendanceRegister.BLL.Models;
using FluentValidation;

namespace AttendanceRegister.BLL.ModelValidators
{
    public class TeacherValidator : AbstractValidator<TeacherModel>
    {
        public TeacherValidator() 
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Неправильний формат електронної адреси");
        }
    }
}
