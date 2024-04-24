using Hospital_2._0.Models;
using Hospital_2._0.Repositories;
using System;

namespace Hospital_2._0.Services
{
    public interface IOccupationService
    {
        Task<List<Occupation>> GetAll();
        Task<Occupation> GetOccupation(int idOccupation);
        Task<Occupation> CreateOccupation(int IdDoctor, DateTime DateOccupation, int IdPaciente, int State);
        Task<Occupation> UpdateOccupation(int IdOccupation, int? IdDoctor, DateTime? DateOccupation, int? IdPaciente, int? State);
        Task<Occupation> DeleteOccupation(int Occupationid, bool Active);

    }
    public class OccupationService : IOccupationService
    {
        private readonly IOccupationRepository _occupationRepository;
        public OccupationService(IOccupationRepository occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }
        public async Task<List<Occupation>> GetAll()
        {
            return await _occupationRepository.GetAll();
        }

        public async Task<Occupation> GetOccupation(int idOccupation)
        {
            return await _occupationRepository.GetOccupation(idOccupation);
        }
        public async Task<Occupation> CreateOccupation(int IdDoctor, DateTime DateOccupation, int IdPaciente, int State)
        {
            return await _occupationRepository.CreateOccupation(IdDoctor, DateOccupation, IdPaciente, State);
        }
        public async Task<Occupation> UpdateOccupation(int IdOccupation, int? IdDoctor, DateTime? DateOccupation, int? IdPaciente, int? State)
        {
            Occupation newOccupation = await _occupationRepository.GetOccupation(IdOccupation);
            if (newOccupation != null)
            {
                if (IdDoctor != null)
                {
                    newOccupation.IdDoctor= IdDoctor;
                    newOccupation.DateOccupation= DateOccupation;
                    newOccupation.IdPaciente = IdPaciente;
                    newOccupation.State= State;

                }
                return await _occupationRepository.UpdateOccupation(newOccupation);
            }
            throw new NotImplementedException();
        }
        public async Task<Occupation> DeleteOccupation(int OccupationID , bool Active)
        {

            Occupation OccupationToDelete = await _occupationRepository.GetOccupation(OccupationID);

            if (OccupationToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                OccupationToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _occupationRepository.UpdateOccupation(OccupationToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("Occupation not found.");
            }
        }
    }
}
