using DoctorAppointment.Services.Unit.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Apponments.Factories
{
    public static class AddAppointmentDtoFactory
    {
        public static AddAppontmentDto Create()
        {
            return new AddAppontmentDto
            {
                DoctorId = 1,
                PatientId = 1,
                AppontmentTime = new DateTime(2024, 03, 01)
            };
        }
    }
}
