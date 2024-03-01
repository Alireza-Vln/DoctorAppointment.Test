using DoctorAppointment.Entities.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Doctors.Builders
{
    public class DoctorBuilder
    {
        readonly Doctor _doctor;

        public DoctorBuilder()
        {
            _doctor = new Doctor()
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-last-name",
                Field = "heart",
                NationCode = "22",
                
               
            };
        }


        public DoctorBuilder WithFirstName(string firstName)
        {
            _doctor.FirstName = firstName;
            return this;

        }
        public DoctorBuilder WithLastName(string lastName)
        {


            _doctor.LastName = lastName;
            return this;
        }
        public DoctorBuilder WithField(string field)
        {


            _doctor.Field = field;
            return this;
        }
        public DoctorBuilder WithNationCode(string nationCode)
        {


            _doctor.NationCode = nationCode;
            return this;
        }
        public Doctor Build()
        {
            return _doctor;
        }





    }
}
