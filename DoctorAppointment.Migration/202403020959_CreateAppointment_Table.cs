using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Migrations
{
    [Migration(202403020959)]
    public class _202403020959_CreateAppointment_Table : Migration
    {
        public override void Up()
        {
            Create.Table("Appointments")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("DoctorId").AsInt32().Nullable()
                .WithColumn("PatientId").AsInt32().Nullable()
                .WithColumn("AppointmentTime").AsDateTime().Nullable();
        }
        public override void Down()
        {

            Delete.Table("Appointments");
        }

      
    }
}
