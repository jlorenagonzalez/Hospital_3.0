using Hospital_2._0.Models;
using Hospital_2._0.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Hospital_2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Resource>>> GetAllResource()
        {
            return Ok(await _resourceService.GetAll());

        }

        [HttpGet("{ResourceId}")]
        public async Task<ActionResult<Resource>> GetResource(int ResourceId)
        {
            var Resource = await _resourceService.GetResource(ResourceId);
            if (Resource == null)
            {
                return BadRequest("User No Fount");
            }
            return Ok(Resource);

        }

        [HttpPost]
        public async Task<ActionResult<Resource>> PostResource(Resource resource)
        {
            try
            {
                var createdResource = await _resourceService.CreateResource(resource.DoctorId, (int)resource.PatientId,(DateTime)resource.AssignmentDate , resource.Description);
                return CreatedAtAction(nameof(GetResource), new { ResourceId = createdResource.ResourceId }, createdResource);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{ResourceId}")]
        public async Task<IActionResult> PutResource(int ResourceId, Resource resource)
        {
            if (ResourceId != resource.ResourceId)
            {
                return BadRequest();
            }

            try
            {
                var updatedResource = await _resourceService.UpdateResource(ResourceId, resource.DoctorId, (int)resource.PatientId, (DateTime)resource.AssignmentDate, resource.Description);
                return Ok(updatedResource);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{ResourceId}")]
        public async Task<IActionResult> DeleteResource(int ResourceId)
        {
            try
            {
                await _resourceService.DeleteResource(ResourceId, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }




    }
}
