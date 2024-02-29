using DoctorAppointment.Services.Doctors.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Doctors.factories
{
    public static class UpdateDoctorDtoFactory
    {

        public static UpdateDoctorDto Creat()
        {
            return new UpdateDoctorDto()
            {
                FirstName = "updated-dummy-first-name",
                LastName = "updated-dummy-last-name",
                Field = "child",
                NationCode = "updated-22",
            };
        }
    }
}
