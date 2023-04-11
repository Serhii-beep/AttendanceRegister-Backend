using Attendanceregister.DAL.Entities;
using Attendanceregister.DAL.Interfaces;
using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Models;
using AttendanceRegister.BLL.ModelValidators;
using AutoMapper;
using FluentValidation.Results;

namespace AttendanceRegister.BLL.Services
{
    public class PupilService : IPupilService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly Validators _validators;

        public PupilService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validators = new Validators();
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

        public async Task<OperationResult<List<PupilModel>>> GetPupilsAsync(string order, int page, int itemsPerPage)
        {
            var pupils = await _unitOfWork.PupilRepository.GetAllWithClasses();
            if(page != 0)
            {
                pupils = pupils.Skip(page * itemsPerPage - 1);
            }
            pupils = pupils.Take(itemsPerPage);
            if(order == "asc")
            {
                pupils = pupils.OrderBy(p => p.FullName);
            }
            if(order == "desc")
            {
                pupils = pupils.OrderByDescending(p => p.FullName);
            }
            return OperationResult<List<PupilModel>>.Success(_mapper.Map<List<PupilModel>>(pupils));
        }

        public async Task<OperationResult<PupilModel>> AddPupilAsync(PupilModel pupil)
        {
            ValidationResult vr = _validators.PupilValidator.Validate(pupil);
            if(!vr.IsValid)
            {
                return OperationResult<PupilModel>.Failture(vr.Errors.Select(e => e.ErrorMessage).ToArray());
            }
            Pupil pupilEntity = _mapper.Map<Pupil>(pupil);
            try
            {
                await _unitOfWork.PupilRepository.AddAsync(pupilEntity);
                await _unitOfWork.SaveAsync();
            }
            catch(Exception ex)
            {
                return OperationResult<PupilModel>.Failture(ex.Message);
            }
            return OperationResult<PupilModel>.Success(_mapper.Map<PupilModel>(pupilEntity));
        }

        public async Task<OperationResult<PupilModel>> DeletePupilByIdAsync(int id)
        {
            try
            {
                await _unitOfWork.PupilRepository.DeleteByIdAsync(id);
                await _unitOfWork.SaveAsync();
            }
            catch(Exception ex)
            {
                return OperationResult<PupilModel>.Failture(ex.Message);
            }
            return OperationResult<PupilModel>.Success(null);
        }

        public async Task<OperationResult<PupilModel>> UpdatePupilAsync(PupilModel pupil)
        {
            ValidationResult vr = _validators.PupilValidator.Validate(pupil);
            if(!vr.IsValid)
            {
                return OperationResult<PupilModel>.Failture(vr.Errors.Select(e => e.ErrorMessage).ToArray());
            }
            Pupil pupilEntity = _mapper.Map<Pupil>(pupil);
            try
            {
                _unitOfWork.PupilRepository.Update(pupilEntity);
                await _unitOfWork.SaveAsync();
            }
            catch(Exception ex)
            {
                return OperationResult<PupilModel>.Failture(ex.Message);
            }
            return OperationResult<PupilModel>.Success(_mapper.Map<PupilModel>(pupilEntity));
        }
    }
}
