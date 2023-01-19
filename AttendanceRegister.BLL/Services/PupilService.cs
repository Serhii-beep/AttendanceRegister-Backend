using Attendanceregister.DAL.Interfaces;
using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Models;
using AutoMapper;

namespace AttendanceRegister.BLL.Services
{
    public class PupilService : IPupilService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public PupilService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult<PupilModel>> GetPupilAsync(string username, string password)
        {
            var pupils = await _unitOfWork.PupilRepository.GetAllAsync();
            var pupil = pupils.FirstOrDefault(p => p.Login == username && p.Password == password);
            if(pupil == null)
            {
                return OperationResult<PupilModel>.Failture("Invalid username or password");
            }
            return OperationResult<PupilModel>.Success(_mapper.Map<PupilModel>(pupil));
        }

        public async Task<OperationResult<List<PupilModel>>> GetAllPupilsAsync()
        {
            var pupils = await _unitOfWork.PupilRepository.GetAllAsync();
            return OperationResult<List<PupilModel>>.Success(_mapper.Map<List<PupilModel>>(pupils));
        }
    }
}
