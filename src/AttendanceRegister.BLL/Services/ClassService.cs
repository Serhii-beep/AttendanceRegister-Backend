using Attendanceregister.DAL.Interfaces;
using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Models;
using AttendanceRegister.BLL.ModelValidators;
using AutoMapper;
using FluentValidation.Results;

namespace AttendanceRegister.BLL.Services
{
    public class ClassService : IClassService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly Validators _validators;

        public ClassService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validators = new Validators();
        }

        public async Task<OperationResult<ClassModel>> DeleteClassByIdAsync(int id)
        {
            var classEntity = await _unitOfWork.ClassRepository.GetByIdAsync(id);
            if(classEntity == null)
            {
                return OperationResult<ClassModel>.Failture($"No class with id = {id}");
            }
            try
            {
                _unitOfWork.ClassRepository.Delete(classEntity);
                await _unitOfWork.SaveAsync();
            }
            catch(Exception ex)
            {
                return OperationResult<ClassModel>.Failture(ex.Message);
            }
            return OperationResult<ClassModel>.Success(_mapper.Map<ClassModel>(classEntity));
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

        public async Task<OperationResult<ClassModel>> UpdateClassAsync(ClassModel classModel)
        {
            ValidationResult vr = _validators.ClassValidator.Validate(classModel);
            if(!vr.IsValid)
            {
                return OperationResult<ClassModel>.Failture(vr.Errors.Select(e => e.ErrorMessage).ToArray());
            }
            var classEntity = await _unitOfWork.ClassRepository.GetByIdAsync(classModel.Id);
            if(classEntity == null)
            {
                return OperationResult<ClassModel>.Failture($"No class with Id = {classModel.Id}");
            }
            try
            {
                _unitOfWork.ClassRepository.Update(classEntity);
                await _unitOfWork.SaveAsync();
            }
            catch(Exception ex)
            {
                return OperationResult<ClassModel>.Failture(ex.Message);
            }
            return OperationResult<ClassModel>.Success(_mapper.Map<ClassModel>(classEntity));
        }
    }
}
