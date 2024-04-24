using Hospital_2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_2._0.Context
{
    public class BedContext: DbContext
    {
        public BedContext(DbContextOptions<BedContext> options) : base(options)
        {


        }

        public DbSet<Bed> Beds { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bed>().HasKey(e => e.BedId);

        }
    }
}
