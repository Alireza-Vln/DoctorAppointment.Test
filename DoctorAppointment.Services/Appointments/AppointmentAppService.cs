using DoctorAppointment.Contracts.Interfaces;

namespace DoctorAppointment.Services.Unit.Tests
{
    public class AppointmentAppService : AppointmentService
    {
       private readonly UnitOfWork _unitOfWork;
        private readonly AppointmentRepository _repository;
        public AppointmentAppService(AppointmentRepository repository,UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork=unitOfWork;
        }

        public async Task Add(AddAppontmentDto dto)
        {
             var doctor= _repository.FindDoctor(dto.DoctorId);
            var patient= _repository.FindPatient(dto.PatientId);
         
            if (doctor == null)
            {
                throw new ThrowAddsAppointmentDoctorWithThePatientIfDoctorIsNullException();
            }
            if (patient== null)
            {
                throw new ThrowAddsAppointmentDoctorWithThePatientIfPatientIsNullException();
            }
            if(dto.AppointmentTime<DateTime.UtcNow)
            {
                throw new ThrowAddsAppointmentDoctorWithThePatientIfDateTimeIsPassedException();
            }
      
            if (_repository.FindDoctorAppointment(doctor.Id,dto.AppointmentTime).Count > 5)
            {
                throw new ThrowAddsAppointmentDoctorWithThePatientIfAppointmentCountBiggerThan5Exception();
            }
           
            var appointment = new Appointment()
            {
                DoctorId = doctor.Id,
                PatientId = patient.Id,
                AppointmentTime = dto.AppointmentTime

            };
          _repository.Add( appointment);
            await _unitOfWork.Complete();
        }

        public async Task<List<Appointment>> GetAll()
        {
          return await _repository.GetAll();
        }
    }
}
