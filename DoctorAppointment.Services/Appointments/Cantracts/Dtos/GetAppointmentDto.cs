namespace DoctorAppointment.Services.Unit.Tests
{
    public class GetAppointmentDto
    {

        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId {get;set;}
        public DateTime AppointmentTime { get; set; }
    }
}
