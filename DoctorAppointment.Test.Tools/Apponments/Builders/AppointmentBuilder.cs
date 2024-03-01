namespace DoctorAppointment.Services.Unit.Tests
{
    public class AppointmentBuilder
    {
        readonly Appointment _appointment;
        public AppointmentBuilder()
        {
            _appointment = new Appointment
            {
                DoctorId = 1,
                PatientId =  1,
                AppointmentTime = new DateTime(2024, 03, 03),
            };
        }
        public AppointmentBuilder WithDoctorId(int doctorId)
        {
            _appointment.DoctorId = doctorId;
            return this;

        }
        public AppointmentBuilder WithPatient(int patientId)
        {

            _appointment.PatientId = patientId;
            return this;
        }
        public AppointmentBuilder WithAppoitmentTime(DateTime appointmentTime)
        {
            _appointment.AppointmentTime = appointmentTime;
            return this;

        }
        public Appointment Build()
        {
            return _appointment;
        }


    }
}
