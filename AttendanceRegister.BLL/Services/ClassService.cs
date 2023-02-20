using Attendanceregister.DAL.Interfaces;
using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Models;
using AutoMapper;

namespace AttendanceRegister.BLL.Services
{
    public class ClassService : IClassService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public ClassService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult<IEnumerable<ClassModel>>> GetAllClassesAsync()
        {
            var classes = await _unitOfWork.ClassRepository.GetAllAsync();
            return OperationResult<IEnumerable<ClassModel>>.Success(_mapper.Map<List<ClassModel>>(classes));
        }

        public async Task<OperationResult<IEnumerable<ClassInfoModel>>> GetClassesIncludedAsync()
        {
            var classes = await _unitOfWork.ClassRepository.GetAllWithProfilesAndPupilsAsync();
            return OperationResult<IEnumerable<ClassInfoModel>>.Success(_mapper.Map<List<ClassInfoModel>>(classes));
        }
    }
}
