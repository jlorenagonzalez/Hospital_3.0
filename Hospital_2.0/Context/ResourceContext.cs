using Hospital_2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_2._0.Context
{
    public class ResourceContext: DbContext
    {
        public ResourceContext(DbContextOptions<ResourceContext> options) : base(options)
        {


        }

        public DbSet<Resource> Resources { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>().HasKey(e => e.ResourceId);

        }
    }
}
