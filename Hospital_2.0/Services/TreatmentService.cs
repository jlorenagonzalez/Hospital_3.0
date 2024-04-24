using Hospital_2._0.Models;
using Hospital_2._0.Repositories;

namespace Hospital_2._0.Services
{
    public interface ITreatmentService
    {
        Task<List<Treatment>> GetAll();
        Task<Treatment> GetTreatment(int idTreatment);
        Task<Treatment> CreateTreatment(int PatientId, int DoctorId, DateTime StartDate, DateTime EndDate, string Description);
        Task<Treatment> UpdateTreatment(int TreatmentId, int ? PatientId, int ? DoctorId, DateTime? StartDate, DateTime? EndDate, string? Description);
        Task<Treatment> DeleteTreatment(int TreatmentID, bool Active);

    }


    public class TreatmentService:ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;

        public TreatmentService(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        public async Task<List<Treatment>> GetAll()
        {
            return await _treatmentRepository.GetAll();
        }
        public async Task<Treatment> GetTreatment(int idTreatment)
        {
            return await _treatmentRepository.GetTreatment(idTreatment);
        }
        public async Task<Treatment> CreateTreatment(int PatientId, int DoctorId, DateTime StartDate, DateTime EndDate, string Description)
        {
            return await _treatmentRepository.CreateTreatment(PatientId,DoctorId,StartDate,EndDate, Description);
        }

        public async Task<Treatment> UpdateTreatment(int TreatmentId, int ? PatientId, int? DoctorId, DateTime? StartDate, DateTime? EndDate, string? Description)
        {
            Treatment newTreatment = await _treatmentRepository.GetTreatment(TreatmentId);
            if (newTreatment != null)
            {
                if (PatientId != null)
                {
                    newTreatment.PatientId = (int)PatientId;
                    newTreatment.DoctorId = (int)DoctorId;
                    newTreatment.StartDate = StartDate;
                    newTreatment.EndDate = EndDate;
                    newTreatment.Description = Description;

                }
                return await _treatmentRepository.UpdateTreatment(newTreatment);
            }
            throw new NotImplementedException();
        }
        public async Task<Treatment> DeleteTreatment(int TreatmentId, bool Active)
        {
            Treatment TreatmentToDelete = await _treatmentRepository.GetTreatment(TreatmentId);

            if (TreatmentToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                TreatmentToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _treatmentRepository.UpdateTreatment(TreatmentToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("User not found.");
            }
        }
    }
}
