using DoctorAppointment.Services.Unit.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Apponments.Factories
{
    public static class UpdateApoointmentDtoFactory
    {
        public static UpdateAppointmentDto Create(DateTime?dateTime=null)
        {
         return   new UpdateAppointmentDto
            {
                AppointmentTime = dateTime??new DateTime(2024,03,03),
            };
        }
}
}
