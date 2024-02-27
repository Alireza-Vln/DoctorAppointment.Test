using DoctorAppointment.Entities.Doctors;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Persistence.EF;

public class EFDataContext : DbContext
{
    public EFDataContext(string connectionString) :
        this(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options)
    { }

     
    public EFDataContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Doctor> Doctors { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{

    //    optionsBuilder.UseSqlServer("Server=.;Database=HospitalDB;Trusted_Connection=True;TrustServerCertificate=True");
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly
            (typeof(EFDataContext).Assembly);
    }
}