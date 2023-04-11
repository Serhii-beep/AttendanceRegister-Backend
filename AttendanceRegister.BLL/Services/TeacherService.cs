using Attendanceregister.DAL.Entities;
using Attendanceregister.DAL.Interfaces;
using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Models;
using AttendanceRegister.BLL.ModelValidators;
using AutoMapper;
using FluentValidation.Results;

namespace AttendanceRegister.BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly Validators _validators;

        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validators = new Validators();
        }

        public async Task<OperationResult<TeacherModel>> AddTeacherAsync(TeacherModel teacher)
        {
            ValidationResult vr = _validators.TeacherValidator.Validate(teacher);
            if(!vr.IsValid)
            {
                return OperationResult<TeacherModel>.Failture(vr.Errors.Select(e => e.ErrorMessage).ToArray());
            }
            Teacher teacherEntity = _mapper.Map<Teacher>(teacher);
            try
            {
                await _unitOfWork.TeacherRepository.AddAsync(teacherEntity);
                await _unitOfWork.SaveAsync();
            }
            catch(Exception ex)
            {
                return OperationResult<TeacherModel>.Failture(ex.Message);
            }
            return OperationResult<TeacherModel>.Success(_mapper.Map<TeacherModel>(teacherEntity));
        }

        public async Task<OperationResult<TeacherModel>> DeleteTeacherByIdAsync(int id)
        {
            try
            {
                await _unitOfWork.TeacherRepository.DeleteByIdAsync(id);
                await _unitOfWork.SaveAsync();
            }
            catch(Exception ex)
            {
                return OperationResult<TeacherModel>.Failture(ex.Message);
            }
            return OperationResult<TeacherModel>.Success(null);
        }

        public async Task<OperationResult<IEnumerable<TeacherModel>>> GetAllTeachersAsync(string order, int page, int itemsPerPage)
        {
            var teachers = await _unitOfWork.TeacherRepository.GetAllAsync();
            if(page != 0)
            {
                teachers = teachers.Skip(page * itemsPerPage - 1);
            }
            teachers = teachers.Take(itemsPerPage);
            if(order == "asc")
            {
                teachers = teachers.OrderBy(p => p.FullName);
            }
            if(order == "desc")
            {
                teachers = teachers.OrderByDescending(p => p.FullName);
            }
            return OperationResult<IEnumerable<TeacherModel>>.Success(_mapper.Map<List<TeacherModel>>(teachers));
        }

        public async Task<OperationResult<TeacherModel>> GetTeacherAsync(string username, string password)
        {
            var teachers = await _unitOfWork.TeacherRepository.GetAllAsync();
            var teacher = teachers.FirstOrDefault(t => t.Login == username && t.Password == password);
            if(teacher == null)
            {
                return OperationResult<TeacherModel>.Failture("Invalid username or password");
            }
            return OperationResult<TeacherModel>.Success(_mapper.Map<TeacherModel>(teacher));
        }

        public async Task<OperationResult<TeacherModel>> UpdateTeacherAsync(TeacherModel teacher)
        {
            ValidationResult vr = _validators.TeacherValidator.Validate(teacher);
            if(!vr.IsValid)
            {
                return OperationResult<TeacherModel>.Failture(vr.Errors.Select(e => e.ErrorMessage).ToArray());
            }
            Teacher teacherEntity = _mapper.Map<Teacher>(teacher);
            try
            {
                _unitOfWork.TeacherRepository.Update(teacherEntity);
                await _unitOfWork.SaveAsync();
            }
            catch(Exception ex)
            {
                return OperationResult<TeacherModel>.Failture(ex.Message);
            }
            return OperationResult<TeacherModel>.Success(_mapper.Map<TeacherModel>(teacherEntity));
        }
    }
}
