using DoctorAppointment.Services.Unit.Tests;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointment.RestApi.Controllers.Patients
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController : Controller
    {
       private readonly PatientService _service;
        public PatientController(PatientService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task Add(AddPatientDto dto)
        {
            await _service.Add(dto);
        }
        [HttpGet]
        public async Task<List<Patient>> GetAll()
        {
            return await _service.GetAll();
        }
        [HttpPatch]

        public async Task Update([FromQuery] int id, [FromBody] UpdatePatientDto dto)
        {
             await _service.Update(id, dto);
        }
        [HttpDelete]
        public async Task Delete([FromQuery] int id)
        {
            await _service.Remove(id);
        }
        
    }
}
