using Hospital_2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_2._0.Context
{
    public class OccupationContext: DbContext
    {
        public OccupationContext(DbContextOptions<OccupationContext> options) : base(options)
        {


        }

        public DbSet<Occupation> Occupations{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Occupation>().HasKey(e => e.OccupationId);

        }
    }
}
