using DoctorAppointment.Services.Unit.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Patients.Builders
{
    public class PatientBuilder
    {
        readonly Patient _patient;
        public PatientBuilder()
        {
            _patient = new Patient()
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-last-name",
                PhoneNumber ="12345",
                NationCode = "54321",
            };

        }
         public PatientBuilder WithFirstName(string firstName)
        {
            _patient.FirstName = firstName;
            return this;
        }
        public PatientBuilder WithLastName(string lastName)
        {
            _patient.LastName = lastName;
            return this;
        }
        public PatientBuilder WithPhoneNumber(string phoneNumber)
        {
            _patient.PhoneNumber = phoneNumber;
            return this;
        }
        public PatientBuilder WithNationCode(string nationCode)
        {
            _patient.NationCode = nationCode;
            return this;
        }

        public Patient Build()
        {
            return _patient;    
        }


    }
}
