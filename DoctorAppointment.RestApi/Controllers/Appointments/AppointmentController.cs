using DoctorAppointment.Services.Unit.Tests;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointment.RestApi.Controllers.Appointments
{
    [ApiController]
    [Route("api/Appointment")]
    public class AppointmentController : Controller
    {
        readonly AppointmentService _service;
        public AppointmentController(AppointmentService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task Add([FromBody] AddAppontmentDto dto)
        {
            await _service.Add(dto);
        }
        [HttpGet]
        public async Task<List<Appointment>> GetAll()
        {
            return await _service.GetAll();
        }
        [HttpDelete]
        public async Task Remove([FromQuery] int id)
        {
            await _service.Remove(id);
        }
        [HttpPatch]
        public async Task Update([FromQuery] int id,UpdateAppointmentDto dto)
        {
            await _service.Update(id, dto);
        
        }
    }
}
