
using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Doctors.Contracts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointment.RestApi.Controllers.Doctors
{
    [ApiController]
    [Route("api/Doctor")]
    public class DoctorController : Controller
    {
        private readonly DoctorService _service;

        public DoctorController(DoctorService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task Add([FromBody] AddDoctorDto dto)
        {
            await _service.Add(dto);
        }

        [HttpGet]
        public async Task<List<Doctor>> GetAll()
        {
          return await _service.GetAll();
        }
        [HttpGet]
        public async Task<int> GetAllCount()
        {
           return await _service.GetAllCount();
        }


        [HttpDelete]
        public async Task Delete(int id)
        {
            await _service.Remove(id);
        }

        [HttpPatch]
        public async Task Update(int id, [FromBody] UpdateDoctorDto dto)
        {
            await _service.Update(id, dto);
        }

    }
}
