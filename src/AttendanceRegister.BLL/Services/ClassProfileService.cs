using Attendanceregister.DAL.Interfaces;
using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Models;
using AutoMapper;

namespace AttendanceRegister.BLL.Services
{
    public class ClassProfileService : IClassProfileService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public ClassProfileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult<IEnumerable<ClassProfileModel>>> GetAllClassesByProfilesAsync()
        {
            var classes = await _unitOfWork.ClassProfileRepository.GetAllWithClassesAsync();
            return OperationResult<IEnumerable<ClassProfileModel>>.Success(_mapper.Map<List<ClassProfileModel>>(classes));
        }

        public async Task<OperationResult<IEnumerable<ClassProfileModel>>> GetAllProfilesAsync()
        {
            var profiles = await _unitOfWork.ClassProfileRepository.GetAllAsync();
            return OperationResult<IEnumerable<ClassProfileModel>>.Success(_mapper.Map<List<ClassProfileModel>>(profiles));
        }
    }
}
