
using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Persistance.EF;
using DoctorAppointment.Persistance.EF.Doctors;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Doctors;
using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Doctors.Contracts.Dto;
using DoctorAppointment.Services.Doctors.Exceptions;
using DoctorAppointment.Test.Tools.Doctors;
using DoctorAppointment.Test.Tools.Doctors.Builders;
using DoctorAppointment.Test.Tools.Doctors.factories;
using DoctorAppointment.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System.Numerics;

namespace DoctorAppointment.Services.Unit.Tests;

public class DoctorServiceTests
{
    private readonly EFDataContext _context;
    private readonly EFDataContext _readContext;
    private readonly DoctorService _sut;

    public DoctorServiceTests()
    {
        var db = new EFInMemoryDatabase();
         _context = db.CreateDataContext<EFDataContext>();
        _readContext = db.CreateDataContext<EFDataContext>();
        _sut = DoctorServiceFactory.Create(_context);
    }

    [Fact]
    public async Task Add_adds_a_new_doctor_properly()
    {

        var dto = AddDoctorDtoFactory.Create();
      
        await _sut.Add(dto);

        var actual = _readContext.Doctors.Single();
        actual.FirstName.Should().Be(dto.FirstName);
        actual.LastName.Should().Be(dto.LastName);
        actual.Field.Should().Be(dto.Field);
        actual.NationCode.Should().Be(dto.NationCode);
    }

    [Fact]
    public async Task Add_throw_doctor_properly_There_is_a_national_doctor_code()
    {
        var doctor = new DoctorBuilder().Build();
        _context.Save(doctor);
        var dto = AddDoctorDtoFactory.Create(doctor.NationCode);

       var action =()=>_sut.Add(dto);

        await action.Should().ThrowExactlyAsync<AddThrowDoctorProperlyThereIsANationalCodeDoctor>();

        
    }


    [Fact]
    public async Task Update_updates_doctor_properly()
    {

        var doctor = new DoctorBuilder().Build();
        _context.Save(doctor);
        var updateDto = UpdateDoctorDtoFactory.Creat();
   
        
      
        await _sut.Update(doctor.Id, updateDto);
        
  
        var actual = _readContext.Doctors.First(_=>_.Id == doctor.Id);
        actual.FirstName.Should().Be(updateDto.FirstName);
        actual.LastName.Should().Be(updateDto.LastName);
        actual.Field.Should().Be(updateDto.Field);
        actual.NationCode.Should().Be(updateDto.NationCode);
    }

    [Fact]
    public async Task Update_throw_doctor_properly_if_doctor_is_id_null()
    {
        var dummyid = 1;
        var updateDto = UpdateDoctorDtoFactory.Creat();

      var action = ()=> _sut.Update(dummyid, updateDto);

        await action.Should().ThrowExactlyAsync<UpdateThrowdoctorProperlyIfDocterIsIdNull>();
    }
    [Fact]
    public async Task Remove_removes_doctor_properly()
    {
        var doctor = new DoctorBuilder().Build();
        _context.Save(doctor);
           
        await _sut.Remove(doctor.Id);

        var actual = await _readContext.Doctors.FirstOrDefaultAsync(_ => _.Id == doctor.Id);
        actual.Should().BeNull();    

    }
    [Fact]
    public async Task Remove_throw_doctor_properly_if_docter_is_id_null()
    {
        var dummyDoctorId = 1;
        var doctor = new DoctorBuilder().Build();

           var action=()=>_sut.Remove(dummyDoctorId);

       await action.Should().ThrowExactlyAsync<RemoveThrowDoctorProperlyIfDocterIsIdNull>();

        
    }

    [Fact]
   public async Task Get_gets_all_for_correct_data_doctor_properly()
    {
       var doctor=new DoctorBuilder().Build();
        _context.Save(doctor);
        var dto = GetDoctorDtoFactory.Create();
  
        await _sut.GetAll();

        var actual=_readContext.Doctors.Single();
        actual.Id.Should().Be(dto.Id);
        actual.FirstName.Should().Be(dto.FirstName);
        actual.LastName.Should().Be(dto.LastName);
        actual.Field.Should().Be(dto.Field);
        actual.NationCode.Should().Be(dto.NationCode);

    }
    [Fact]
    public async Task Get_gets_all_for_count_data_docter_properly()
    {
        var doctor = new DoctorBuilder().Build();
       _context.Save(doctor);
        var dto = GetDoctorDtoFactory.Create();

        await _sut.GetAll();

      var actual = _readContext.Doctors.ToList();
      actual.Count.Should().Be(1);  

    }

}
