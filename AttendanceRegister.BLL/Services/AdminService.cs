using Attendanceregister.DAL.Interfaces;
using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Models;
using AutoMapper;

namespace AttendanceRegister.BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult<object>> GetUserAsync(string username, string password)
        {
            var admins = await _unitOfWork.AdminRepository.GetAllAsync();
            var teachers = await _unitOfWork.TeacherRepository.GetAllAsync();
            var pupils = await _unitOfWork.PupilRepository.GetAllAsync();
            var admin = admins.FirstOrDefault(a => a.Login == username && a.Password == password);
            if(admin != null)
            {
                return OperationResult<object>.Success(_mapper.Map<AdminModel>(admin));
            }
            var teacher = teachers.FirstOrDefault(t => t.Login == username && t.Password == password);
            if(teacher != null)
            {
                return OperationResult<object>.Success(_mapper.Map<TeacherModel>(teacher));
            }
            var pupil = pupils.FirstOrDefault(p => p.Login == username && p.Password == password);
            if(pupil != null)
            {
                return OperationResult<object>.Success(_mapper.Map<PupilModel>(pupil));
            }
            return OperationResult<object>.Failture($"Invalid username or password");
        }
    }
}
