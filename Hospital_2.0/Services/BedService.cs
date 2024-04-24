using Hospital_2._0.Migrations.Bed;
using Hospital_2._0.Models;
using Hospital_2._0.Repositories;

namespace Hospital_2._0.Services
{
    public interface IBedService
    {
        Task<List<Bed>> GetAll();
        Task<Bed> GetBed(int idBed);
        Task<Bed> CreateBed(string TypeBed, int PatientId, String Availability);
        Task<Bed> UpdateBed(int BedId, string? TypeBed, int? PatientId, String? Availability);
        Task<Bed> DeleteBed(int IdBed , bool Active);
    }
    public class BedService:IBedService
    {
        private readonly IBedRepository _bedRepository;
        public BedService(IBedRepository bedRepository)
        {
            _bedRepository = bedRepository;
        }

        public async Task<List<Bed>> GetAll()
        {
            return await _bedRepository.GetAll();
        }

        public async Task<Bed> GetBed(int idBed)
        {
            return await _bedRepository.GetBed(idBed);
        }
        public async Task<Bed> CreateBed(string TypeBed, int PatientId, string Availability)
        {
            return await _bedRepository.CreateBed(TypeBed, PatientId, Availability);
        }

        public async Task<Bed> UpdateBed(int BedId, string? TypeBed, int? PatientId, string? Availability)
        {
            Bed newBed = await _bedRepository.GetBed(BedId);
            if (newBed != null)
            {
                if (PatientId != null)
                {
                    newBed.TypeBed = TypeBed;
                    newBed.PatientId = PatientId;
                    newBed.Availability = Availability;
                }
                return await _bedRepository.UpdateBed(newBed);
            }
            throw new NotImplementedException();
        }

        public async Task<Bed> DeleteBed(int IdBed, bool Active)
        {
            Bed bedToDelete = await _bedRepository.GetBed(IdBed);

            if (bedToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                bedToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _bedRepository.UpdateBed(bedToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("bed not found.");
            }
        }
    }

}

