using DoctorAppointment.Entities.Doctors;

namespace DoctorAppointment.Services.Unit.Tests
{
    public interface AppointmentRepository
    {
        void Add( Appointment appointment);
        Doctor? FindDoctor(int DoctorId);
        Patient? FindPatient (int PatientId);
        List<Appointment> FindDoctorAppointment
            (int doctorId, DateTime dateDoctor);
        Task<List<Appointment>> GetAll();
        Appointment? FindAppointment(int id);
        Task Remove(Appointment appointment);
    }
}
