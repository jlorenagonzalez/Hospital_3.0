using Hospital_2._0.Models;
using Microsoft.EntityFrameworkCore;


namespace Hospital_2._0.Context
{
    public class PatientDbContext: DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {


        }

        public DbSet<Patient> Patients { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasKey(e => e.PatientId);

        }
        public DbSet<Hospital_2._0.Models.Doctor> Doctor { get; set; } = default!;
    }
}
