namespace DoctorAppointment.Services.Unit.Tests
{
    public static class GetPatientDtoFactory
    {
        public static GetPatientDto Create()
        {
            return new GetPatientDto()
            {

                Id = 1,
                FirstName = "dummy-first-name",
                LastName = "dummy-last-name",
                PhoneNumber = "12345",
                NationCode = "54321"
            };
        }
    }
}
