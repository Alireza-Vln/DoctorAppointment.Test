namespace DoctorAppointment.Services.Unit.Tests
{
    public interface PatientService
    {
        Task Add(AddPatientDto dto);
        Task <List<Patient>> GetAll();
        Task Remove(int id);
        Task Update(int id, UpdatePatientDto dto);
    }
}
