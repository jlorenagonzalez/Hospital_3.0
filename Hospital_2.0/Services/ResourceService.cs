using Hospital_2._0.Models;
using Hospital_2._0.Repositories;

namespace Hospital_2._0.Services
{
    public interface IResourceService
    {
        Task<List<Resource>> GetAll();
        Task<Resource> GetResource(int idResource);
        Task<Resource> CreateResource(int DoctorId, int PatientId, DateTime AssignmentDate, string Description);
        Task<Resource> UpdateResource(int ResourceId, int ? DoctorId, int? PatientId, DateTime? AssignmentDate, string? Description);
        Task<Resource> DeleteResource(int resourceid, bool Active);

    }
    public class ResourceService: IResourceService
    {
        private readonly IResourceRepository _resourceRepository;
        public ResourceService(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public async Task<List<Resource>> GetAll()
        {
            return await _resourceRepository.GetAll();
        }

        public async Task<Resource> GetResource(int idResource)
        {
            return await _resourceRepository.GetResource(idResource);
        }
        public async Task<Resource> CreateResource(int DoctorId, int PatientId, DateTime AssignmentDate, string Description)
        {
            return await _resourceRepository.CreateResource(DoctorId,PatientId,AssignmentDate,Description);
        }

        public async Task<Resource> UpdateResource(int ResourceId, int? DoctorId, int? PatientId, DateTime? AssignmentDate, string? Description)
        {
            Resource newResource = await _resourceRepository.GetResource(ResourceId);
            if (newResource != null)
            {
                if (DoctorId != null)
                {
                    newResource.DoctorId = (int)DoctorId;
                    newResource.PatientId = PatientId;
                    newResource.AssignmentDate = AssignmentDate;
                    newResource.Description = Description;
                }
                return await _resourceRepository.UpdateResource(newResource);
            }
            throw new NotImplementedException();
        }
        public async Task<Resource> DeleteResource(int ResourceId, bool Active)
        {
            Resource ResourceToDelete = await _resourceRepository.GetResource(ResourceId);

            if (ResourceToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                ResourceToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _resourceRepository.UpdateResource(ResourceToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("Resource not found.");
            }
        }
    }
}
