using AttendanceRegister.BLL.Models;
using FluentValidation;

namespace AttendanceRegister.BLL.ModelValidators
{
    public class PupilValidator : AbstractValidator<PupilModel>
    {
        public PupilValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Неправильний формат електронної адреси");
            RuleFor(x => x.BirthDate).InclusiveBetween(DateTime.Now.Subtract(new TimeSpan(365 * 19, 0, 0, 0)),
                DateTime.Now.Subtract(new TimeSpan(365 * 5, 0, 0, 0))).WithMessage("Вік учнів повинен бути від 5 до 19 років");
        }
    }
}
