using Hospital_2._0.Context;
using Hospital_2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_2._0.Repositories
{
    public interface IBedRepository
    {
        Task<List<Bed>> GetAll();
        Task<Bed> GetBed(int idBed);
        Task<Bed> CreateBed(string TypeBed, int PatientId, String Availability);
        Task<Bed> UpdateBed(Bed bed);
        Task<Bed> DeleteBed(Bed bed);

    }

    public class BedsRepository:IBedRepository
    {
        private readonly BedContext _db;
        public BedsRepository(BedContext db)
        {
            _db = db;
        }

        public async Task<List<Bed>> GetAll()
        {
            return await _db.Beds.ToListAsync();
        }

        public async Task<Bed> GetBed(int idBed)
        {
            return await _db.Beds.FirstOrDefaultAsync(u => u.BedId == idBed);
        }
        public async Task<Bed> CreateBed(string TypeBed, int PatientId, string Availability)
        {
            Bed newBed = new Bed
            {
               TypeBed = TypeBed,
               PatientId = PatientId,
               Availability = Availability

            };
            await _db.Beds.AddAsync(newBed);
            _db.SaveChangesAsync();
            return newBed;
        }
        public async Task<Bed> UpdateBed(Bed bed)
        {
            _db.Beds.Update(bed);
            await _db.SaveChangesAsync();
            return bed;
        }
        public async Task<Bed> DeleteBed(Bed bed)
        {
            _db.Beds.Update(bed);
            await _db.SaveChangesAsync();
            return bed;
        }
    }
}
