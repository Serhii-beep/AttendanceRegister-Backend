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
                
            }
            return OperationResult<IEnumerable<SubjectModel>>.Success(subjectModels);
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
    }
}
