using DoctorAppointment.Contracts.Interfaces;
using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Persistance.EF;
using DoctorAppointment.Persistance.EF.Doctors;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Doctors;
using DoctorAppointment.Services.Doctors.Exceptions;
using DoctorAppointment.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using DoctorAppointment.Test.Tools.Patients.Builders;
using DoctorAppointment.Test.Tools.Patients.Factories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Unit.Tests
{
    public class PatientServiceTests
    {
        private readonly PatientService _sut;
        private readonly EFDataContext _context;
        private readonly EFDataContext _readContext;

        public PatientServiceTests()
        {
            var db = new EFInMemoryDatabase();
            _context = db.CreateDataContext<EFDataContext>();
            _readContext = db.CreateDataContext<EFDataContext>();
            _sut = PatientServiceFactory.Create(_context);
        }

        [Fact]
        public async Task Add_adds_a_new_patient_properly()
        {
            var dto = AddPatientDtoFactory.Create();

            await _sut.Add(dto);

            var actual = _readContext.Patients.Single();
            actual.FirstName.Should().Be(dto.FirstName);
            actual.LastName.Should().Be(dto.LastName);
            actual.PhoneNumber.Should().Be(dto.PhonNumber);
            actual.NationCode.Should().Be(dto.NationCode);
        }

        [Fact]
        public async Task Add_throw_exception_patient_properly_there_is_a_national_code_patient()
        {

            var patient = new PatientBuilder().Build();
            _context.Save(patient);
            var dto = AddPatientDtoFactory.Create(patient.NationCode);


            var actual = () => _sut.Add(dto);



            await actual.Should().ThrowExactlyAsync<AddThrowExceptionPatientProperlyThereisanationalcodepatient>();

        }
        [Fact]
        public async Task Update_updates_patient_properly()
        {

            var patient = new PatientBuilder().Build();
            _context.Save(patient);

            var dto = UpdatePatientDtoFactory.Create();


            await _sut.Update(patient.Id, dto);

            var actual = _readContext.Patients.First(_ => _.Id == patient.Id);
            actual.FirstName.Should().Be(dto.FirstName);
            actual.LastName.Should().Be(dto.LastName);
            actual.PhoneNumber.Should().Be(dto.PhonNumber);
            actual.NationCode.Should().Be(dto.NationCode);

        }
        [Fact]
        public async Task Update_throw_exception_patient_properly_if_patient_is_id_null()
        {
            var dummyId = 1;
            var dto = UpdatePatientDtoFactory.Create();


            var action = () => _sut.Update(dummyId, dto);

            await action.Should().ThrowExactlyAsync<ThrowExceptionPatientProperlyIfPatientIsIdNull>();
        }

        [Fact]
        public async Task Remove_removes_patient_properly()
        {
           var patient = new PatientBuilder().Build();
           _context.Save(patient);
            

             await _sut.Remove(patient.Id);

            var actual = await _readContext.Patients.FirstOrDefaultAsync(_ => _.Id == patient.Id);

            actual.Should().BeNull();



        }
        [Fact]
        public async Task Remove_throw_exception_patient_properly_if_patient_is_id_null()
        {
           
            var dummyid = 1;
            var patient = new PatientBuilder().Build();

            var action = () => _sut.Remove(dummyid);

            await action.Should().ThrowExactlyAsync<ThrowExceptionPatientProperlyIfPatientIsIdNull>();


        }

        [Fact]
        public async Task Get_gets_all_for_correct_data_patien_properly()
        {
       
            var patien = new PatientBuilder().Build();
      
           _context.Save(patien);


            var dto =GetPatientDtoFactory.Create();
           
            await _sut.GetAll();

            var actual = _readContext.Patients.Single();
            actual.Id.Should().Be(dto.Id);
            actual.FirstName.Should().Be(dto.FirstName);
            actual.LastName.Should().Be(dto.LastName);
            actual.PhoneNumber.Should().Be(dto.PhoneNumber);
            actual.NationCode.Should().Be(dto.NationCode);

        }
    }
}
