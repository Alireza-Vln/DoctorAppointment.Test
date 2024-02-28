namespace DoctorAppointment.Services.Unit.Tests
{
    public interface PatientRepository
    {
        Task Add(Patient patient);
        Task<Patient?> FindById(int id);
        Task<List<Patient>> GetAll();
        bool IsExist(string nationCode);
        void Remove(Patient patient);
    }
}
