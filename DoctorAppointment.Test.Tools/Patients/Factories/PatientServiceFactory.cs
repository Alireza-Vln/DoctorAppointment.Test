using DoctorAppointment.Contracts.Interfaces;
using DoctorAppointment.Persistance.EF;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Doctors;
using DoctorAppointment.Services.Unit.Tests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Patients.Factories
{
  public static class PatientServiceFactory
    {
        public static PatientService Create(EFDataContext context)
        {

            return new PatientAppService(new EFPatientRepository(context), new EFUnitOfWork(context));
        }
    }
}
