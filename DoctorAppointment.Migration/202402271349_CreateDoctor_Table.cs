using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Migrations
{
   public class _202402271349_CreateDoctor_Table : Migration
    {
        public override void Up()
        {
            Create.Table("Doctors")
                 .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                 .WithColumn("FirstName").AsString().NotNullable()
                 .WithColumn("LastName").AsString().NotNullable()
                 .WithColumn("Field").AsString().NotNullable()
                 .WithColumn("NationCode").AsString().NotNullable();
                
        }
        public override void Down()
        {
            Delete.Table("Doctors");
        }

       
    }
}
