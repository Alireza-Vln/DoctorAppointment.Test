namespace DoctorAppointment.Services.Unit.Tests
{
    public interface AppointmentService
    {
        Task Add(AddAppontmentDto dto);
        Task<List<Appointment>> GetAll();
        Task Remove(int id);
        Task Update(int  id, UpdateAppointmentDto Dto);
    }
}