using System.ComponentModel.DataAnnotations;

namespace DoctorAppointment.Services.Unit.Tests
{
    public class  AddAppontmentDto
    {

        [Required]
        public int DoctorId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public DateTime AppointmentTime { get; set; }
    }
}
