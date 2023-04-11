using Attendanceregister.DAL.Entities;
using Attendanceregister.DAL.Interfaces;
using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Models;
using AttendanceRegister.BLL.ModelValidators;
using AutoMapper;

namespace AttendanceRegister.BLL.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Validators _validators;

        public SubjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validators = new Validators();
        }

        public async Task<OperationResult<SubjectModel>> AddSubjectAsync(SubjectModel newSubject)
        {
            var vr = _validators.SubjectValidator.Validate(newSubject);
            if(!vr.IsValid)
            {
                return OperationResult<SubjectModel>.Failture(vr.Errors.Select(e => e.ErrorMessage).ToArray());
            }
            try
            {
                await _unitOfWork.SubjectRepository.AddAsync(_mapper.Map<Subject>(newSubject));
                await _unitOfWork.SaveAsync();
            }
            catch(Exception ex)
            {
                return OperationResult<SubjectModel>.Failture(ex.Message);
            }
            return OperationResult<SubjectModel>.Success(newSubject);
        }

        public async Task<OperationResult<bool>> DeleteSubjectAsync(int id)
        {
            try
            {
                await _unitOfWork.SubjectRepository.DeleteByIdAsync(id);
                await _unitOfWork.SaveAsync();
            }
            catch(Exception ex)
            {
                return OperationResult<bool>.Failture(ex.Message);
            }
            return OperationResult<bool>.Success(true);
        }

        public async Task<OperationResult<IEnumerable<SubjectModel>>> GetAllSubjectsAsync()
        {
            var subjects = await _unitOfWork.SubjectRepository.GetAllAsync();
            var subjectModels = _mapper.Map<IEnumerable<SubjectModel>>(subjects);
            foreach(var subjectModel in subjectModels)
            {
                var teacherSubject = await _unitOfWork.TeacherSubjectRepository.GetAllAsync();
                var teacherIds = teacherSubject.Where(ts => ts.SubjectId == subjectModel.Id).Select(x => x.TeacherId).Distinct().ToList();
                subjectModel.Teachers = new();
                var teachers = await _unitOfWork.TeacherRepository.GetAllAsync();
                var selectedTeacher = teachers.Where(t => teacherIds.Contains(t.Id));
                subjectModel.Teachers.AddRange(_mapper.Map<IEnumerable<TeacherModel>>(selectedTeacher));
                var classesSubject = await _unitOfWork.SubjectClassRepository.GetAllAsync();
                var classesIds = classesSubject.Where(cs => cs.SubjectId == subjectModel.Id).Select(x => x.ClassId).Distinct().ToList();
                subjectModel.Classes = new();
                var classes = await _unitOfWork.ClassRepository.GetAllAsync();
                var selectedClasses = classes.Where(c => classesIds.Contains(c.Id));
                subjectModel.Classes.AddRange(_mapper.Map<IEnumerable<ClassModel>>(selectedClasses));

            }
            return OperationResult<IEnumerable<SubjectModel>>.Success(subjectModels);
        }

        public async Task<OperationResult<SubjectModel>> UpdateSubjectTeachersClassesAsync(SubjectModel subjectModel)
        {
            var updateTeachersRes = await UpdateSubjectTeachersAsync(subjectModel);
            return updateTeachersRes.IsSuccess ? await UpdateSubjectClasses(subjectModel) : updateTeachersRes;
        }

        public async Task<OperationResult<SubjectModel>> UpdateSubjectAsync(SubjectModel subjectModel)
        {
            var vr = _validators.SubjectValidator.Validate(subjectModel);
            if(!vr.IsValid)
            {
                return OperationResult<SubjectModel>.Failture(vr.Errors.Select(e => e.ErrorMessage).ToArray());
            }
            try
            {
                _unitOfWork.SubjectRepository.Update(_mapper.Map<Subject>(subjectModel));
                await _unitOfWork.SaveAsync();
            }
            catch(Exception ex)
            {
                return OperationResult<SubjectModel>.Failture(ex.Message);
            }
            return OperationResult<SubjectModel>.Success(subjectModel);
        }

        public async Task<OperationResult<SubjectModel>> UpdateSubjectTeachersAsync(SubjectModel newModel)
        {
            var allCurrent = await _unitOfWork.TeacherSubjectRepository.GetAllAsync();
            var currentTeachers = allCurrent.Where(x => x.SubjectId == newModel.Id);
            var toRemove = allCurrent.Where(x => !newModel.Teachers.Any(t => t.Id == x.TeacherId) && x.SubjectId == newModel.Id).ToList();
            foreach(var rem in toRemove)
            {
                _unitOfWork.TeacherSubjectRepository.Delete(rem);
            }
            var toAdd = newModel.Teachers.Where(t => !allCurrent.Any(x => x.TeacherId == t.Id && x.SubjectId == newModel.Id));
            foreach(var add in toAdd)
            {
                await _unitOfWork.TeacherSubjectRepository.AddAsync(new()
                {
                    TeacherId = add.Id,
                    SubjectId = newModel.Id,
                });
            }
            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch(Exception ex)
            {
                return OperationResult<SubjectModel>.Failture(ex.Message);
            }
            return OperationResult<SubjectModel>.Success(newModel);
        }

        public async Task<OperationResult<SubjectModel>> UpdateSubjectClasses(SubjectModel newModel)
        {
            var allCurrent = await _unitOfWork.SubjectClassRepository.GetAllAsync();
            var currentClasses = allCurrent.Where(x => x.SubjectId == newModel.Id);
            var toRemove = allCurrent.Where(x => !newModel.Classes.Any(c => c.Id == x.ClassId) && x.SubjectId == newModel.Id).ToList();
            foreach(var rem in toRemove)
            {
                _unitOfWork.SubjectClassRepository.Delete(rem);
            }
            var toAdd = newModel.Classes.Where(c => !allCurrent.Any(x => x.ClassId == c.Id && x.SubjectId == newModel.Id));
            foreach(var add in toAdd)
            {
                await _unitOfWork.SubjectClassRepository.AddAsync(new()
                {
                    ClassId = add.Id,
                    SubjectId = newModel.Id,
                });
            }
            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch(Exception ex)
            {
                return OperationResult<SubjectModel>.Failture(ex.Message);
            }
            return OperationResult<SubjectModel>.Success(newModel);
        }

        public async Task<OperationResult<SubjectModel>> GetSubjectByIdAsync(int id)
        {
            var subject = await _unitOfWork.SubjectRepository.GetByIdAsync(id);
            var subjectModel = _mapper.Map<SubjectModel>(subject);
            var teacherSubject = await _unitOfWork.TeacherSubjectRepository.GetAllAsync();
            var teacherIds = teacherSubject.Where(ts => ts.SubjectId == subjectModel.Id).Select(x => x.TeacherId).Distinct().ToList();
            subjectModel.Teachers = new();
            var teachers = await _unitOfWork.TeacherRepository.GetAllAsync();
            var selectedTeacher = teachers.Where(t => teacherIds.Contains(t.Id));
            subjectModel.Teachers.AddRange(_mapper.Map<IEnumerable<TeacherModel>>(selectedTeacher));
            var classesSubject = await _unitOfWork.SubjectClassRepository.GetAllAsync();
            var classesIds = classesSubject.Where(cs => cs.SubjectId == subjectModel.Id).Select(x => x.ClassId).Distinct().ToList();
            subjectModel.Classes = new();
            var classes = await _unitOfWork.ClassRepository.GetAllAsync();
            var selectedClasses = classes.Where(c => classesIds.Contains(c.Id));
            subjectModel.Classes.AddRange(_mapper.Map<IEnumerable<ClassModel>>(selectedClasses));
            return OperationResult<SubjectModel>.Success(subjectModel);
        }
    }
}
