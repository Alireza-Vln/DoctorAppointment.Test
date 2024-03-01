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
        public static AddAppontmentDto Create(DateTime?appointmentTime=null,int?patientId=null)
        {
            return new AddAppontmentDto
            {
                DoctorId = 1,
                PatientId = patientId ?? 1,
                AppointmentTime = appointmentTime?? new DateTime(2024, 03, 03),
            };
        }
    }
}
