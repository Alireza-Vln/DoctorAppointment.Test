using DoctorAppointment.Persistence.EF;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Patient?> FindById(int id)
        {
           return await _context.Patients.FirstOrDefaultAsync(_ => _.Id == id);
        }

        public bool IsExist(string nationCode)
        {
            return _context.Patients.Any(_ => _.NationCode == nationCode);
        }
    }
}
