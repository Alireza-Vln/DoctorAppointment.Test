namespace DoctorAppointment.Services.Unit.Tests
{
    public interface PatientRepository
    {
        Task Add(Patient patient);
        Task<Patient?> FindById(int id);
        bool IsExist(string nationCode);
    }
}
