using Attendanceregister.DAL.Interfaces;
using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Models;
using AutoMapper;

namespace AttendanceRegister.BLL.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult<IEnumerable<SubjectModel>>> GetAllSubjectsAsync()
        {
            var subjects = await _unitOfWork.SubjectRepository.GetAllAsync();
            return OperationResult<IEnumerable<SubjectModel>>.Success(_mapper.Map<List<SubjectModel>>(subjects));
        }
    }
}
