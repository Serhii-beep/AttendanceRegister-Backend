namespace AttendanceRegister.BLL.ModelValidators
{
    public class Validators
    {
        public PupilValidator PupilValidator { get; } = new PupilValidator();

        public ClassValidator ClassValidator { get; } = new ClassValidator();

        public TeacherValidator TeacherValidator { get; } = new TeacherValidator();
    }
}
