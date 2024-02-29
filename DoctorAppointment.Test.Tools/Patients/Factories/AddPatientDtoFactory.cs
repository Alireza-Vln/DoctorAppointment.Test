using DoctorAppointment.Services.Unit.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Patients.Factories
{
   public static class AddPatientDtoFactory
    {
        public static AddPatientDto Create(string? nationCode = null)
        {
            return new AddPatientDto()
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-Last-name",
                PhonNumber = "123456",
                NationCode = nationCode ?? "54321",
            };
        }

    }
}
