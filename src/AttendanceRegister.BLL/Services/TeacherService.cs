using Attendanceregister.DAL.Interfaces;
using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Models;
using AutoMapper;

namespace AttendanceRegister.BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult<TeacherModel>> GetTeacherAsync(string username, string password)
        {
            var teachers = await _unitOfWork.TeacherRepository.GetAllAsync();
            var teacher = teachers.FirstOrDefault(t => t.Login == username && t.Password == password);
            if(teacher == null)
            {
                return OperationResult<TeacherModel>.Failture("Invalid username or password");
            }
            return OperationResult<TeacherModel>.Success(_mapper.Map<TeacherModel>(teacher));
        }
    }
}
