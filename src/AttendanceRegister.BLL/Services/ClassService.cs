using Attendanceregister.DAL.Entities;
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

        public async Task<OperationResult<ClassModel>> AddClassAsync(ClassModel classModel)
        {
            var profile = await _unitOfWork.ClassProfileRepository.GetByIdAsync(classModel.ClassProfileId);
            if(profile == null)
            {
                return OperationResult<ClassModel>.Failture("Such profile does not exist");
            }
            var classes = await _unitOfWork.ClassRepository.GetAllAsync();
            var classEntity = classes.FirstOrDefault(c => c.Name == classModel.Name);
            if(classEntity != null)
            {
                return OperationResult<ClassModel>.Failture($"Class {classEntity.Name} already exists");
            }
            var vr = _validators.ClassValidator.Validate(classModel);
            if(!vr.IsValid)
            {
                return OperationResult<ClassModel>.Failture(vr.Errors.Select(e => e.ErrorMessage).ToArray());
            }
            try
            {
                await _unitOfWork.ClassRepository.AddAsync(_mapper.Map<Class>(classModel));
                await _unitOfWork.SaveAsync();
            }
            catch(Exception ex)
            {
                return OperationResult<ClassModel>.Failture(ex.Message);
            }
            return OperationResult<ClassModel>.Success(classModel);
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

        public async Task<OperationResult<ClassModel>> GetClassByIdAsync(int id)
        {
            var classEntity = await _unitOfWork.ClassRepository.GetByIdWithProfileAsync(id);
            if(classEntity == null)
            {
                return OperationResult<ClassModel>.Failture($"No class with id = {id}");
            }
            return OperationResult<ClassModel>.Success(_mapper.Map<ClassModel>(classEntity));
        }

        public async Task<OperationResult<IEnumerable<ClassInfoModel>>> GetClassesByTeacherAsync(int teacherId)
        {
            var classes = await _unitOfWork.ClassRepository.GetAllWithProfilesAndPupilsAsync();
            var classesSubjects = await _unitOfWork.SubjectClassRepository.GetAllAsync();
            var teachersSubjects = await _unitOfWork.TeacherSubjectRepository.GetAllAsync();
            var filteredTeachersSubjects = teachersSubjects.Where(ts => ts.TeacherId == teacherId);
            var filteredClassesSubjects = classesSubjects.Where(cs => filteredTeachersSubjects.Any(ts => ts.SubjectId == cs.SubjectId));
            var filteredClasses = classes.Where(c => filteredClassesSubjects.Any(cs => cs.ClassId == c.Id)).ToList();
            var teachers = await _unitOfWork.TeacherRepository.GetAllAsync();
            var classInfo = new List<ClassInfoModel>();
            foreach(var classEntity in filteredClasses)
            {
                classInfo.Add(new()
                {
                    Id = classEntity.Id,
                    Name = classEntity.Name,
                    ProfileName = classEntity.ClassProfile.ProfileName,
                    NumberOfPupils = classEntity.Pupils.Count,
                    Supervisor = teachers.FirstOrDefault(t => t.Id == classEntity.TeacherId)?.FullName
                });
            }
            return OperationResult<IEnumerable<ClassInfoModel>>.Success(classInfo);
        }

        public async Task<OperationResult<IEnumerable<ClassInfoModel>>> GetClassesIncludedAsync()
        {
            var classes = await _unitOfWork.ClassRepository.GetAllWithProfilesAndPupilsAsync();
            var teachers = await _unitOfWork.TeacherRepository.GetAllAsync();
            var classInfo = new List<ClassInfoModel>();
            foreach(var classEntity in classes)
            {
                classInfo.Add(new()
                {
                    Id = classEntity.Id,
                    Name = classEntity.Name,
                    ProfileName = classEntity.ClassProfile.ProfileName,
                    NumberOfPupils = classEntity.Pupils.Count,
                    Supervisor = teachers.FirstOrDefault(t => t.Id == classEntity.TeacherId)?.FullName
                });
            }
            return OperationResult<IEnumerable<ClassInfoModel>>.Success(classInfo);
        }

        public async Task<OperationResult<ClassModel>> UpdateClassAsync(ClassModel classModel)
        {
            ValidationResult vr = _validators.ClassValidator.Validate(classModel);
            if(!vr.IsValid)
            {
                return OperationResult<ClassModel>.Failture(vr.Errors.Select(e => e.ErrorMessage).ToArray());
            }
            var classEntity = _mapper.Map<Class>(classModel);
            try
            {
                _unitOfWork.ClassRepository.Update(classEntity);
                await _unitOfWork.SaveAsync();
            }
            catch(Exception ex)
            {
                return OperationResult<ClassModel>.Failture(ex.InnerException.Message);
            }
            return OperationResult<ClassModel>.Success(_mapper.Map<ClassModel>(classEntity));
        }
    }
}
