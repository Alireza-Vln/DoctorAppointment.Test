using DoctorAppointment.Services.Doctors.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Doctors
{
    public static class AddDoctorDtoFactory
    {
        public static AddDoctorDto Create()
        {
            return new AddDoctorDto()
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-last-name",
                Field = "heart",
                NationCode = "22",
            };
        }
    }
}
