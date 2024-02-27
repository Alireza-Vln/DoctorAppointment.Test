namespace DoctorAppointment.Services.Unit.Tests
{
    public interface PatientRepository
    {
        Task Add(Patient patient);
        bool IsExist(string nationCode);
    }
}
