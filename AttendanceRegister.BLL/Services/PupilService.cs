﻿using Attendanceregister.DAL.Interfaces;
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

        public async Task<OperationResult<List<PupilModel>>> GetPupils(string order, int page, int itemsPerPage)
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
    }
}
