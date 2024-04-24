using Hospital_2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_2._0.Context
{
    public class TreatmentContext: DbContext
    {
        public TreatmentContext(DbContextOptions<TreatmentContext> options) : base(options)
        {


        }

        public DbSet<Treatment> Treatments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Treatment>().HasKey(e => e.TreatmentId);

        }
    }
}
