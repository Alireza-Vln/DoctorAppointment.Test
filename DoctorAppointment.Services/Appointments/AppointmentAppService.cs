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
           
            var appointment = new Appointment()
            {
                DoctorId = doctor.Id,
                PatientId = patient.Id,
                AppointmentTime = dto.AppontmentTime

            };
          _repository.Add( appointment);
            await _unitOfWork.Complete();
        }
    }
}
