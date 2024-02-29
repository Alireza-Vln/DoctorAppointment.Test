using DoctorAppointment.Services.Unit.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Patients.Factories
{
    public static class UpdatePatientDtoFactory
    {
        public static UpdatePatientDto Create()
        {
            return new UpdatePatientDto()
            {
                FirstName = "update_dummy-first-name",
                LastName = "update_dummy-Last-name",
                PhonNumber = "update_123456",
                NationCode = "update_54321",
            };
        }
    }
}
