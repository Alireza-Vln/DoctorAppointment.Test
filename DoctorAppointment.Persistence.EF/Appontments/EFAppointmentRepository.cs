using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Services.Unit.Tests
{
    public class EFAppointmentRepository : AppointmentRepository
    {
        private EFDataContext _context;

        public EFAppointmentRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(Appointment appointment)
        {
          
        _context.Appointments.Add(appointment);

        }

        public Doctor? FindDoctor(int DoctorId)
        {
            return _context.Doctors.FirstOrDefault(_ => _.Id == DoctorId);
        }

        public Patient? FindPatient(int PatientId)
        {
            return _context.Patients.FirstOrDefault(_=>_.Id == PatientId);
        }
    }
}
