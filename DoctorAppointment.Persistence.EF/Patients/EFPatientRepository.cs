using DoctorAppointment.Persistence.EF;

namespace DoctorAppointment.Services.Unit.Tests
{
    public class EFPatientRepository : PatientRepository
    {
        readonly EFDataContext _context;
        public EFPatientRepository(EFDataContext context)
        {
            _context = context;
        }

        public async Task Add(Patient patient)
        {
          await _context.Patients.AddAsync(patient);
        }
    }
}
