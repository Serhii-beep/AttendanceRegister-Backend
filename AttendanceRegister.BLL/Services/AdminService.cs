using Attendanceregister.DAL.Interfaces;
using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Models;
using AutoMapper;

namespace AttendanceRegister.BLL.Services
{
    public class AdminService : IAdminService
    {
        private IUnitOfWork _unitOfWork;

        private IMapper _mapper;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult<AdminModel>> GetAdminAsync(string username, string password)
        {
            var admins = await _unitOfWork.AdminRepository.GetAllAsync();
            var admin = admins.FirstOrDefault(a => a.Login == username && a.Password == password);
            if(admin == null)
            {
                return OperationResult<AdminModel>.Failture("Invalid username or password");
            }
            return OperationResult<AdminModel>.Success(_mapper.Map<AdminModel>(admin));
        }
    }
}
