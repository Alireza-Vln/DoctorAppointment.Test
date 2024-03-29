﻿using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Services.Unit.Tests
{
    public class EFAppointmentRepository : AppointmentRepository
    {
        private EFDataContext _context;

        public EFAppointmentRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(Appointment appointment)
        {
          
        _context.Appointments.Add(appointment);

        }

        public Doctor? FindDoctor(int DoctorId)
        {
            return _context.Doctors.FirstOrDefault(_ => _.Id == DoctorId);
        }


        public Patient? FindPatient(int PatientId)
        {
            return _context.Patients.FirstOrDefault(_ => _.Id == PatientId);
        }
        public List<Appointment> FindDoctorAppointment
            (int doctorId,DateTime dateDoctor)
        {

            return _context.Doctors.FirstOrDefault(_ => _.Id == doctorId)
                .AppointmentList.Where(_=>_.AppointmentTime==dateDoctor).ToList();
        }

        public async Task<List<Appointment>> GetAll()
        {
           return  _context.Appointments.ToList();
        }

        public Appointment? FindAppointment(int id)
        {
            return _context.Appointments.FirstOrDefault(_ => _.Id == id);
        }

        public async Task Remove(Appointment appointment)
        {
             _context.Appointments.Remove(appointment);
        }
    }
}
