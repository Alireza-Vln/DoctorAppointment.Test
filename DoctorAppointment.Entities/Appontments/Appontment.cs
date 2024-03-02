using DoctorAppointment.Entities.Doctors;

namespace DoctorAppointment.Services.Unit.Tests
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentTime { get; set; }
       // public Doctor Doctor { get; set; }
        //public Patient Patient { get; set; }
    }
}
