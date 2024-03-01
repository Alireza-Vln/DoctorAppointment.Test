using DoctorAppointment.Persistance.EF;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Unit.Tests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Apponments.Factories
{
    public static class AppointmentServiceFactory
    {
        public static AppointmentService Create(EFDataContext context)
        {
            return new AppointmentAppService
                (new EFAppointmentRepository(context), new EFUnitOfWork(context));
        }
    }
}
