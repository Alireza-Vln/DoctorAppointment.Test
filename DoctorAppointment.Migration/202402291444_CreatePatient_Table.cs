using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Migrations
{
    [Migration(202402291444)]
    public class _202402291444_CreatePatient_Table : Migration
    {
       
        public override void Up()
        {
           Create.Table("Patients")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                 .WithColumn("FirstName").AsString(50).NotNullable()
                 .WithColumn("LastName").AsString(50).NotNullable()
                 .WithColumn("PhoneNumber").AsString(30).NotNullable()
                 .WithColumn("NationCode").AsString(11).NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Patients");
        }
    }
}
