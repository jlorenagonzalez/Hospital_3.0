using Hospital_2._0.Context;
using Hospital_2._0.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net;

namespace Hospital_2._0.Repositories
{
    public interface IOccupationRepository
    {
        Task<List<Occupation>> GetAll();
        Task<Occupation> GetOccupation(int idOccupation);
        Task<Occupation> CreateOccupation(int IdDoctor, DateTime DateOccupation, int IdPaciente, int State);
        Task<Occupation> UpdateOccupation(Occupation occupation);
        Task<Occupation> DeleteOccupation(Occupation occupation);

    }


    public class OccupationRepository : IOccupationRepository
    {
        private readonly OccupationContext _db;
        public OccupationRepository(OccupationContext db)
        {
            _db = db;
        }
        public async Task<List<Occupation>> GetAll()
        {
            return await _db.Occupations.ToListAsync();
        }

        public async Task<Occupation> GetOccupation(int idOccupation)
        {
            return await _db.Occupations.FirstOrDefaultAsync(u => u.OccupationId == idOccupation);
        }
        public async Task<Occupation> CreateOccupation(int IdDoctor, DateTime DateOccupation, int IdPaciente, int State)
        {
            Occupation newOccupation = new Occupation
            {
              IdDoctor = IdDoctor,
              DateOccupation = DateOccupation,
              IdPaciente = IdPaciente,
              State = State,
            };
            await _db.Occupations.AddAsync(newOccupation);
            _db.SaveChangesAsync();
            return newOccupation;
        }
        public async Task<Occupation> UpdateOccupation(Occupation occupation)
        {
            _db.Occupations.Update(occupation);
            await _db.SaveChangesAsync();
            return occupation;
        }
        public async Task<Occupation> DeleteOccupation(Occupation occupation)
        {
            _db.Occupations.Update(occupation);
            await _db.SaveChangesAsync();
            return occupation;
        }
    }
}
