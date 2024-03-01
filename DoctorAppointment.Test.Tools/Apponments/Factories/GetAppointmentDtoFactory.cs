namespace DoctorAppointment.Services.Unit.Tests
{
    public static class GetAppointmentDtoFactory
    {
        public static GetAppointmentDto Create()
        {
            return new GetAppointmentDto()
            {
                Id = 1,
                DoctorId = 1,
                PatientId = 1,
                AppointmentTime = new DateTime(2024, 03, 03),
            };
        }
    }
}
