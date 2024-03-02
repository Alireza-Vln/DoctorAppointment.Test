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
            _context = db.CreateDataContext<EFDataContext>();
            _readContext = db.CreateDataContext<EFDataContext>();
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
            actual.AppointmentTime.Should().Be(dto.AppointmentTime);

        }
        [Fact]

        public async Task Throw_adds_appointment_doctor_with_the_patient_if_doctor_is_null_exception()
        {

            var patient = new PatientBuilder().Build();
            _context.Save(patient);
            var dto = AddAppointmentDtoFactory.Create();

            var actual = async () => await _sut.Add(dto);

            await actual.Should().ThrowExactlyAsync<ThrowAddsAppointmentDoctorWithThePatientIfDoctorIsNullException>();
        }
        [Fact]
        public async Task Throw_adds_appointment_doctor_with_the_patient_if_patient_is_null_exception()
        {
            var doctor = new DoctorBuilder().Build();
            _context.Save(doctor);
            var dto = AddAppointmentDtoFactory.Create();

            var actual = async () => await _sut.Add(dto);

            await actual.Should().ThrowExactlyAsync<ThrowAddsAppointmentDoctorWithThePatientIfPatientIsNullException>();
        }
        [Fact]
        public async Task Throw_adds_appointment_doctor_with_the_patient_if_date_time_is_passed()
        {
            var dummydatetime = new DateTime(2020, 1, 2);
            var doctor = new DoctorBuilder().Build();
            _context.Save(doctor);
            var patient = new PatientBuilder().Build();
            _context.Save(patient);
            var dto = AddAppointmentDtoFactory.Create(dummydatetime);

            var actual = async () => await _sut.Add(dto);

            await actual.Should().ThrowExactlyAsync<ThrowAddsAppointmentDoctorWithThePatientIfDateTimeIsPassedException>();
        }
        [Fact]

        public void Throw_adds_appointment_doctor_with_the_patient_if_appointment_count_bigger_than_5()
        {
            var doctor = new DoctorBuilder().Build();
            _context.Save(doctor);

            var patient1 = new PatientBuilder().Build();
            _context.Save(patient1);
            var patient2 = new PatientBuilder().Build();
            _context.Save(patient2);
            var patient3 = new PatientBuilder().Build();
            _context.Save(patient3);
            var patient4 = new PatientBuilder().Build();
            _context.Save(patient4);
            var patient5 = new PatientBuilder().Build();
            _context.Save(patient5);
            var patient6 = new PatientBuilder().Build();
            _context.Save(patient6);

            var dto1 = AddAppointmentDtoFactory.Create(new DateTime(2024, 03, 03), 1);
            var dto2 = AddAppointmentDtoFactory.Create(new DateTime(2024, 03, 03), 2);
            var dto3 = AddAppointmentDtoFactory.Create(new DateTime(2024, 03, 03), 3);
            var dto4 = AddAppointmentDtoFactory.Create(new DateTime(2024, 03, 03), 4);
            var dto5 = AddAppointmentDtoFactory.Create(new DateTime(2024, 03, 03), 5);
            var dto6 = AddAppointmentDtoFactory.Create(new DateTime(2024, 03, 03), 5);

            var action1 =   _sut.Add(dto1);
            var action2 =   _sut.Add(dto2);
            var action3 =   _sut.Add(dto3);
            var action4 =   _sut.Add(dto4);
            var action5 =   _sut.Add(dto5);
          
            var actual =()=> _sut.Add(dto6);
            actual.Should().ThrowExactlyAsync<ThrowAddsAppointmentDoctorWithThePatientIfAppointmentCountBiggerThan5Exception>();
        }
        [Fact]
        public void get_gets_appointment_doctor_with_the_patient()
        {
              var doctor=new DoctorBuilder().Build();
            var patient=new PatientBuilder().Build();
            var appointment=new AppointmentBuilder().Build();
            _context.Save(doctor);
            _context.Save(patient);
            _context.Save(appointment);
            var dto = GetAppointmentDtoFactory.Create();
          
             _sut.GetAll();

            var actual = _readContext.Appointments.Single();
            actual.Id.Should().Be(dto.Id);
            actual.DoctorId.Should().Be(dto.DoctorId);
            actual.PatientId.Should().Be(dto.PatientId);
            actual.AppointmentTime.Should().Be(dto.AppointmentTime);
        }
        [Fact]



        public void Remove_removes_appointment_doctor_with_the_patient()
        {
            var doctor = new DoctorBuilder().Build();
            var patient = new PatientBuilder().Build();
            var appointment = new AppointmentBuilder().Build();
            _context.Save(doctor);
            _context.Save(patient);
            _context.Save(appointment);
            
            _sut.Remove(appointment.Id);

            var actual = _readContext.Appointments.FirstOrDefault(_=>_.Id==appointment.Id);
             actual.Should().BeNull();
           
        }
        [Fact]
        public void Throw_removes_appointment_doctor_with_the_patient_if_appointment_is_null_exception()
        {
            var doctor = new DoctorBuilder().Build();
            var patient = new PatientBuilder().Build();
            var appointment = new AppointmentBuilder().Build();
            _context.Save(doctor);
            _context.Save(patient);
            _context.Save(appointment);
            var actual=()=> _sut.Remove(appointment.Id);


            actual.Should().ThrowExactlyAsync<ThrowRemoveAppointmentDoctorWithThePatientIfAppointmentIsNullException>();
        }
    }
}
