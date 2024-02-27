using DoctorAppointment.Contracts.Interfaces;
using DoctorAppointment.Persistance.EF;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Doctors.Exceptions;
using DoctorAppointment.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Unit.Tests
{
    public class PatientServiceTests
    {


        [Fact]
        public async Task Add_adds_a_new_patient_properly()
        {
            var db = new EFInMemoryDatabase();
            var context = db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();
            var sut = new PatientAppService(new EFPatientRepository(context), new EFUnitOfWork(context));

            var dto = new AddPatientDto()
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-Last-name",
                PhonNumber = "123456",
                NationCode = "54321",
            };

            await sut.Add(dto);

            var actual = readContext.Patients.Single();
            actual.FirstName.Should().Be(dto.FirstName);
            actual.LastName.Should().Be(dto.LastName);
            actual.PhonNumber.Should().Be(dto.PhonNumber);
            actual.NationCode.Should().Be(dto.NationCode);
        }

        [Fact]
        public async Task Add_throw_exception_patient_properly_there_is_a_national_code_patient()
        {
            var db = new EFInMemoryDatabase();
            var Context = db.CreateDataContext<EFDataContext>();
            var patient = new Patient()
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-Last-name",
                PhonNumber = "123456",
                NationCode = "54321",
            };
            Context.Save(patient);
            var dto = new AddPatientDto()
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-Last-name",
                PhonNumber = "123456",
                NationCode = "54321",
            };

            var sut = new PatientAppService(new EFPatientRepository(Context), new EFUnitOfWork(Context));

            var actual = () => sut.Add(dto);



            await actual.Should().ThrowExactlyAsync<AddThrowExceptionPatientProperlyThereisanationalcodepatient>();

        }
        [Fact]
        public async Task Update_updates_patient_properly()
        {
            var db = new EFInMemoryDatabase();
            var context = db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();
            var patient = new Patient()
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-Last-name",
                PhonNumber = "123456",
                NationCode = "54321",
            };
            context.Save(patient);
            var sut = new PatientAppService(new EFPatientRepository(context), new EFUnitOfWork(context));
            var dto = new UpdatePatientDto()
            {
                FirstName = "update_dummy-first-name",
                LastName = "update_dummy-Last-name",
                PhonNumber = "update_123456",
                NationCode = "update_54321",
            };

            await sut.Update(patient.Id, dto);

            var actual = readContext.Patients.First(_ => _.Id == patient.Id);
            actual.FirstName.Should().Be(dto.FirstName);
            actual.LastName.Should().Be(dto.LastName);
            actual.PhonNumber.Should().Be(dto.PhonNumber);
            actual.NationCode.Should().Be(dto.NationCode);

        }
        [Fact]
        public async Task Update_throw_exception_patient_properly_if_patient_is_id_null()
        {
           var db=new EFInMemoryDatabase();
            var context = db.CreateDataContext<EFDataContext>();
            var dummyId = 1;
            var sut=new PatientAppService(new EFPatientRepository(context),new EFUnitOfWork(context));

            var dto = new UpdatePatientDto()
            {
                FirstName = "update_dummy-first-name",
                LastName = "update_dummy-Last-name",
                PhonNumber = "update_123456",
                NationCode = "update_54321",
            };


            var action=()=>sut.Update(dummyId, dto);

            await action.Should().ThrowExactlyAsync<UpdateThrowExceptionPatientProperlyIfPatientIsIdNull>();
        }


    }
}
