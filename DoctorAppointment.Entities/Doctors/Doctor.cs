using DoctorAppointment.Services.Unit.Tests;

namespace DoctorAppointment.Entities.Doctors;

public class Doctor
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Field { get; set; }
    public string NationCode { get; set; }
    public List<Appointment> AppointmentList { get; set; }

    public Doctor()
    {
        AppointmentList = new();
    }
}
