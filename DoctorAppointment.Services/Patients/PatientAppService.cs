using DoctorAppointment.Contracts.Interfaces;

namespace DoctorAppointment.Services.Unit.Tests
{
    public class PatientAppService: PatientService
    {
        public readonly PatientRepository _repsitory;
        public readonly UnitOfWork _unitOfWork;
        public PatientAppService(PatientRepository repository,UnitOfWork unitOfWork)
        {
            _repsitory=repository;
            _unitOfWork=unitOfWork;
        }

        public async Task Add(AddPatientDto dto)
        {
            var patient = new Patient()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhonNumber = dto.PhonNumber,
                NationCode = dto.NationCode
            };
            await _repsitory.Add(patient);
            await _unitOfWork.Complete();
        }
    }
}
