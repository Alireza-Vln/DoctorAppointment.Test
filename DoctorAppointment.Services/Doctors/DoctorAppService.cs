using DoctorAppointment.Contracts.Interfaces;
using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Doctors.Contracts.Dto;
using DoctorAppointment.Services.Doctors.Exceptions;
using DoctorAppointment.Services.Unit.Tests;

namespace DoctorAppointment.Services.Doctors;

public class DoctorAppService : DoctorService
{
    private readonly DoctorRepository _repository;
    private readonly UnitOfWork _unitOfWork;

    public DoctorAppService(
        DoctorRepository repository,
        UnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Add(AddDoctorDto dto)
    {
        if (_repository.IsExist(dto.NationCode))
        {
            throw new AddThrowDoctorProperlyThereIsANationalCodeDoctor();
        }

        var doctor = new Doctor()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Field = dto.Field,
            NationCode = dto.NationCode,
            
        };


        _repository.Add(doctor);
        await _unitOfWork.Complete();
    }

    public async Task<List<Doctor>> GetAll()
    {
        return await _repository.GetAll();

    }

    public async Task<int> GetAllCount()
    {
       return await _repository.GetAllCount();  
    }

    public async Task Remove(int id)
    {
       var docter= await _repository.FindById(id);
        if(docter == null)
        {
        throw new RemoveThrowDoctorProperlyIfDocterIsIdNull();
        
        }
        _repository.Remove(docter);
        await _unitOfWork.Complete();
    }

    public async Task Update(int id, UpdateDoctorDto dto)
    {
        var doctor = await _repository.FindById(id);
        if (doctor == null)
        {
            throw new UpdateThrowoctorProperlyIfDocterIsIdNull();
        }
        doctor.FirstName = dto.FirstName;
        doctor.LastName = dto.LastName;
        doctor.Field = dto.Field;

        await _unitOfWork.Complete();
    }
}