using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Services.Doctors.Contracts.Dto;

namespace DoctorAppointment.Services.Doctors.Contracts;

public interface DoctorService
{
    Task Add(AddDoctorDto dto);
    Task< List<Doctor>> GetAll();
    Task<int> GetAllCount();
    Task Remove(int id);
    Task Update(int id, UpdateDoctorDto dto);
}