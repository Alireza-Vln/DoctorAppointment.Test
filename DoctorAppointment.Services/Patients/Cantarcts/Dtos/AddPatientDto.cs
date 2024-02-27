using System.ComponentModel.DataAnnotations;

namespace DoctorAppointment.Services.Unit.Tests
{
    public class AddPatientDto
    {
        [Required]
        public string FirstName { get;  set; }
        [Required]
        public string LastName { get;  set; }
        [Required]
        public string PhonNumber { get;  set; }
        [Required]
        public string NationCode { get; set; }
    }
}
