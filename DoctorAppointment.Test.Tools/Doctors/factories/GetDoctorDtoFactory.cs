using DoctorAppointment.Services.Unit.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Doctors.factories
{
    public static class GetDoctorDtoFactory
    {
        public static GetDocterDto Create()
        {
            return new GetDocterDto()
            {
                Id = 1,
                FirstName = "dummy-first-name",
                LastName = "dummy-last-name",
                Field = "heart",
                NationCode = "22"
            };

        }


    }
}
