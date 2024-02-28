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
            if (_repsitory.IsExist(dto.NationCode))
            {
                throw new AddThrowExceptionPatientProperlyThereisanationalcodepatient();
            }
            var patient = new Patient()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhonNumber,
                NationCode = dto.NationCode
            };
           
            await _repsitory.Add(patient);
            await _unitOfWork.Complete();
        }

        public async Task<List<Patient>> GetAll()
        {
            return await _repsitory.GetAll();
        }

        public async Task Remove(int id)
        {
            var patient=await _repsitory.FindById(id);
            if (patient == null)
            {
                throw new ThrowExceptionPatientProperlyIfPatientIsIdNull();
            }

            _repsitory.Remove(patient);
            await _unitOfWork.Complete();
        }

        public async Task Update(int id, UpdatePatientDto dto)
        {
          var patient= await _repsitory.FindById(id);
            if (patient==null)
            {

               throw new ThrowExceptionPatientProperlyIfPatientIsIdNull();
            
            }

            patient.FirstName = dto.FirstName;
            patient.LastName = dto.LastName;
            patient.PhoneNumber = dto.PhonNumber;
            patient.NationCode = dto.NationCode;

            await _unitOfWork.Complete();

        
        }
    }
}
