
using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Persistance.EF;
using DoctorAppointment.Persistance.EF.Doctors;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Doctors;
using DoctorAppointment.Services.Doctors.Contracts.Dto;
using DoctorAppointment.Services.Doctors.Exceptions;
using DoctorAppointment.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System.Numerics;

namespace DoctorAppointment.Services.Unit.Tests;

public class DoctorServiceTests
{
    [Fact]
    public async Task Add_adds_a_new_doctor_properly()
    {
        //arrange
        var dto = new AddDoctorDto
        {
            FirstName = "dummy-first-name",
            LastName = "dummy-last-name",
            Field = "heart",
            NationCode = "22",
        };
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var readContext = db.CreateDataContext<EFDataContext>();
        var sut = new DoctorAppService(new EFDoctorRepository(context), new EFUnitOfWork(context));

        //act
        await sut.Add(dto);

        //assert
        var actual = readContext.Doctors.Single();
        actual.FirstName.Should().Be(dto.FirstName);
        actual.LastName.Should().Be(dto.LastName);
        actual.Field.Should().Be(dto.Field);
        actual.NationCode.Should().Be(dto.NationCode);
    }

    [Fact]
    public async Task Add_throw_doctor_properly_There_is_a_national_doctor_code()
    {
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();


        var docter = new Doctor
        {
            FirstName = "dummy-first-name",
            LastName = "dummy-last-name",
            Field = "heart",
            NationCode = "22",
        };
        context.Save(docter);
        var sut = new DoctorAppService(new EFDoctorRepository(context), new EFUnitOfWork(context));
        var dto = new AddDoctorDto
        {
            FirstName = "dummy2-first-name",
            LastName = "dummy2-last-name",
            Field = "heart",
            NationCode = "22",
        };



       var action =()=>sut.Add(dto);

       

        await action.Should().ThrowExactlyAsync<AddThrowDoctorProperlyThereIsANationalCodeDoctor>();

        
    }




    [Fact]
    public async Task Update_updates_doctor_properly()
    {
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var readContext = db.CreateDataContext<EFDataContext>();
        //arrange
        var doctor = new Doctor
        {
            FirstName = "dummy-first-name",
            LastName = "dummy-last-name",
            Field = "heart",
            NationCode="22",
        };
        context.Save(doctor);
        var sut = new DoctorAppService(new EFDoctorRepository(context), new EFUnitOfWork(context));
        var updateDto = new UpdateDoctorDto
        {
            FirstName = "updated-dummy-first-name",
            LastName = "updated-dummy-last-name",
            Field = "child",
            NationCode = "22",

        };
        
        //act
        await sut.Update(doctor.Id, updateDto);
        
        //assert
        var actual = readContext.Doctors.First(_=>_.Id == doctor.Id);
        actual.FirstName.Should().Be(updateDto.FirstName);
        actual.LastName.Should().Be(updateDto.LastName);
        actual.Field.Should().Be(updateDto.Field);
        actual.NationCode.Should().Be(updateDto.NationCode);
    }

    [Fact]
    public async Task Update_throw_doctor_properly_if_docter_is_id_null()
    {


        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
     
        //arrange

        var dummyid = 1;
        var sut = new DoctorAppService(new EFDoctorRepository(context), new EFUnitOfWork(context));
        var updateDto = new UpdateDoctorDto
        {
            FirstName = "updated-dummy-first-name",
            LastName = "updated-dummy-last-name",
            Field = "child",
            NationCode="22",
            
        };

        //act
      var action = ()=> sut.Update(dummyid, updateDto);


        //assert

        await action.Should().ThrowExactlyAsync<UpdateThrowoctorProperlyIfDocterIsIdNull>();

    }
    [Fact]
    public async Task Remove_removes_doctor_properly()
    {
        var db=new EFInMemoryDatabase();
        var context=db.CreateDataContext<EFDataContext>();
        var readContext=db.CreateDataContext<EFDataContext>();
        var docter = new Doctor()
        {
            FirstName = "dummy-first-name",
            LastName = "dummy-last-name",
            Field = "heart",
            NationCode = "22",
        };
        context.Save(docter);
        var sut=new DoctorAppService(new EFDoctorRepository(context), new EFUnitOfWork(context));

        
        await sut.Remove(docter.Id);


        var actual = readContext.Doctors.FirstOrDefaultAsync(_ => _.Id == docter.Id);
        actual.Result.Should().BeNull();    

    }
    [Fact]
    public async Task Remove_throw_doctor_properly_if_docter_is_id_null()
    {
        var db=new EFInMemoryDatabase();
        var context=db.CreateDataContext<EFDataContext>();
        var readContext = db.CreateDataContext<EFDataContext>();
        var dummyDocterId = 1;
        var docter = new Doctor()
        {
            FirstName = "dummy-first-name",
            LastName = "dummy-last-name",
            Field = "heart",
            NationCode = "22",
        };
       var sut=new DoctorAppService(new EFDoctorRepository(context),new EFUnitOfWork(context));


           var action=()=>sut.Remove(dummyDocterId);



       await action.Should().ThrowExactlyAsync<RemoveThrowDoctorProperlyIfDocterIsIdNull>();

        
    }

    [Fact]
   public async Task Get_gets_all_for_correct_data_docter_properly()
    {
        var db=new EFInMemoryDatabase();
        var context= db.CreateDataContext<EFDataContext>();
        var readcontext= db.CreateDataContext<EFDataContext>();
        var doctor = new Doctor()
        {
            Id = 1,
            FirstName = "get-dummy-first-name",
            LastName = "get-dummy-last-name",
            Field = "haert",
            NationCode = "22",
        };
        context.Save(doctor);
 
        var sut=new DoctorAppService(new EFDoctorRepository(context), new EFUnitOfWork(context));

        var dto = new GetDocterDto()
        {
            Id = 1,
            FirstName = "get-dummy-first-name",
            LastName = "get-dummy-last-name",
            Field = "haert",
            NationCode = "22",

        };
        await sut.GetAll();


        var actual=readcontext.Doctors.Single();
        actual.Id.Should().Be(dto.Id);
        actual.FirstName.Should().Be(dto.FirstName);
        actual.LastName.Should().Be(dto.LastName);
        actual.Field.Should().Be(dto.Field);
        actual.NationCode.Should().Be(dto.NationCode);

    }
    [Fact]
    public async Task Get_gets_all_for_count_data_docter_properly()
    {
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var readcontext = db.CreateDataContext<EFDataContext>();
        var doctor = new Doctor()
        {
            Id = 1,
            FirstName = "get-dummy-first-name",
            LastName = "get-dummy-last-name",
            Field = "haert",
            NationCode = "22",
        };
        context.Save(doctor);

        var sut = new DoctorAppService(new EFDoctorRepository(context), new EFUnitOfWork(context));

        var dto = new GetDocterDto()
        {
            Id = 1,
            FirstName = "get-dummy-first-name",
            LastName = "get-dummy-last-name",
            Field = "haert",
            NationCode = "22",

        };
        await sut.GetAll();


      var actual = readcontext.Doctors.ToList();
      actual.Count.Should().Be(1);  

    }

}
