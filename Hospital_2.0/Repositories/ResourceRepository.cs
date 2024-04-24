using Hospital_2._0.Context;
using Hospital_2._0.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net;

namespace Hospital_2._0.Repositories
{
    public interface IResourceRepository
    {
        Task<List<Resource>> GetAll();
        Task<Resource> GetResource(int idResource);
        Task<Resource> CreateResource(int DoctorId, int PatientId, DateTime AssignmentDate, string Description);
        Task<Resource> UpdateResource(Resource resource);
        Task<Resource> DeleteResource(Resource resource);

    }

    public class ResourceRepository : IResourceRepository
    {
        private readonly ResourceContext _db;
        public ResourceRepository(ResourceContext db)
        {
            _db = db;
        }

        public async Task<List<Resource>> GetAll()
        {
            return await _db.Resources.ToListAsync();
        }
        public async Task<Resource> GetResource(int idResource)
        {
            return await _db.Resources.FirstOrDefaultAsync(u => u.ResourceId == idResource);
        }

        public async Task<Resource> CreateResource(int DoctorId, int PatientId, DateTime AssignmentDate, string Description)
        {
            Resource newResource = new Resource
            {
             DoctorId = DoctorId,   
             PatientId = PatientId,
             AssignmentDate = AssignmentDate,
             Description = Description
            };
            await _db.Resources.AddAsync(newResource);
            _db.SaveChangesAsync();
            return newResource;
        }

        public async Task<Resource> UpdateResource(Resource resource)
        {
            _db.Resources.Update(resource);
            await _db.SaveChangesAsync();
            return resource;
        }
        public async Task<Resource> DeleteResource(Resource resource)
        {
            _db.Resources.Update(resource);
            await _db.SaveChangesAsync();
            return resource;
        }
     }
}
