using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Persistance.EF;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Test.Tools.Apponments.Factories;
using DoctorAppointment.Test.Tools.Doctors.Builders;
using DoctorAppointment.Test.Tools.Doctors.factories;
using DoctorAppointment.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using DoctorAppointment.Test.Tools.Patients.Builders;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Unit.Tests
{
    public class AppointmentServiceTests
    {
        private readonly EFDataContext _context;
        private readonly EFDataContext _readContext;
        private readonly AppointmentService _sut;
        public AppointmentServiceTests()
        {
            var db = new EFInMemoryDatabase();
            _context=db.CreateDataContext<EFDataContext>();
            _readContext=db.CreateDataContext<EFDataContext>();
            _sut = AppointmentServiceFactory.Create(_context);
        }

        [Fact]
        public async Task Add_adds_appointment_doctor_with_the_patient()
        {
            var doctor = new DoctorBuilder().Build();
            _context.Save(doctor);
            var patient = new PatientBuilder().Build();
            _context.Save(patient);
            var dto = AddAppointmentDtoFactory.Create();

           await _sut.Add(dto);

            var actual = _readContext.Appointments.Single();
            actual.DoctorId.Should().Be(doctor.Id);
            actual.PatientId.Should().Be(patient.Id);
            actual.AppointmentTime.Should().Be(new DateTime(2024, 03, 01));

        }


    }
}
