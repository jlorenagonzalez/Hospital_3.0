using Hospital_2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_2._0.Context
{
    public class DoctorContext:DbContext
    {
        public DoctorContext(DbContextOptions<DoctorContext> options) : base(options)
        {


        }

        public DbSet<Doctor> Doctors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasKey(e => e.DoctorId);

        }
    }
}
