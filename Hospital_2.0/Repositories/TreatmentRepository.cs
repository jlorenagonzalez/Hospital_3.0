using Hospital_2._0.Context;
using Hospital_2._0.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net;

namespace Hospital_2._0.Repositories
{
    public interface ITreatmentRepository
    {
        Task<List<Treatment>> GetAll();
        Task<Treatment> GetTreatment(int idTreatment);
        Task<Treatment> CreateTreatment(int PatientId, int DoctorId, DateTime StartDate, DateTime EndDate, string Description);
        Task<Treatment> UpdateTreatment(Treatment treatment);
        Task<Treatment> DeleteTreatment(Treatment treatment);

    }

    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly TreatmentContext _db;
        public TreatmentRepository(TreatmentContext db)
        {
            _db = db;
        }
        public async Task<List<Treatment>> GetAll()
        {
            return await _db.Treatments.ToListAsync();
        }
        public async Task<Treatment> GetTreatment(int idTreatment)
        {
            return await _db.Treatments.FirstOrDefaultAsync(u => u.TreatmentId == idTreatment);
        }

        public async Task<Treatment> CreateTreatment(int PatientId, int DoctorId, DateTime StartDate, DateTime EndDate, string Description)
        {
            Treatment newTreatment = new Treatment
            {
             PatientId = PatientId,   
             DoctorId = DoctorId,
             StartDate = StartDate,
             EndDate = EndDate,
             Description = Description

            };
            await _db.Treatments.AddAsync(newTreatment);
            _db.SaveChangesAsync();
            return newTreatment;
        }
        public async Task<Treatment> UpdateTreatment(Treatment treatment)
        {
            _db.Treatments.Update(treatment);
            await _db.SaveChangesAsync();
            return treatment;
        }

        public async Task<Treatment> DeleteTreatment(Treatment treatment)
        {
            _db.Treatments.Update(treatment);
            await _db.SaveChangesAsync();
            return treatment;
        }
    }
}
