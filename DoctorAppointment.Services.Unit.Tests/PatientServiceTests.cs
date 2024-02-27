using DoctorAppointment.Persistance.EF;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FluentAssertions;
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
            var db=new EFInMemoryDatabase();
            var context=db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();
            var sut = new PatientAppService(new EFPatientRepository(context),new EFUnitOfWork (context));

            var dto = new AddPatientDto()
            {
                FirstName="dummy-first-name",
                LastName="dummy-Last-name",
                PhonNumber="dummy-fist-name",
                NationCode="dummy-fist-name",
            };

            await sut.Add(dto);

            var actual=readContext.Patients.Single();
            actual.FirstName.Should().Be(dto.FirstName);
            actual.LastName.Should().Be(dto.LastName);
            actual.PhonNumber.Should().Be(dto.PhonNumber);
            actual.NationCode.Should().Be(dto.NationCode);
        }
    }
}
