using DoctorAppointment.Persistance.EF;
using DoctorAppointment.Persistance.EF.Doctors;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Doctors;
using DoctorAppointment.Services.Doctors.Contracts;

namespace DoctorAppointment.Test.Tools.Doctors
{
    public static class DoctorServiceFactory
    {
        public static DoctorService Create(EFDataContext context)
        { 

            return new DoctorAppService(new EFDoctorRepository(context), new EFUnitOfWork(context));
        }
    }
}
