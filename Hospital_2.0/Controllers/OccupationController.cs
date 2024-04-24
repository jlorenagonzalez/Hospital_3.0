using Hospital_2._0.Models;
using Hospital_2._0.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
            private readonly IOccupationService _occupationService;

            public OccupationController(IOccupationService occupationService)
            {
            _occupationService = occupationService;
            }

            [HttpGet]
            public async Task<ActionResult<List<Occupation>>> GetAllOccupation()
            {
                return Ok(await _occupationService.GetAll());

            }

            [HttpGet("{OccupationId}")]
            public async Task<ActionResult<Occupation>> GetOccupation(int OccupationId)
            {
                var Occupation = await _occupationService.GetOccupation(OccupationId);
                if (Occupation == null)
                {
                    return BadRequest("User No Fount");
                }
                return Ok(Occupation);

            }



        [HttpPost]
        public async Task<ActionResult<Occupation>> PostOccupation(Occupation occupation)
        {
            try
            {
                var createdOccupation = await _occupationService.CreateOccupation((int)occupation.IdDoctor, (DateTime)occupation.DateOccupation, (int)occupation.IdPaciente, (int)occupation.State);
                return CreatedAtAction(nameof(GetOccupation), new { OccupationId = createdOccupation.OccupationId }, createdOccupation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{OccupationId}")]
        public async Task<IActionResult> PutOccupation(int OccupationId, Occupation occupation)
        {
            if (OccupationId != occupation.OccupationId)
            {
                return BadRequest();
            }

            try
            {
                var updatedOccupation = await _occupationService.UpdateOccupation(OccupationId, (int)occupation.IdDoctor, (DateTime)occupation.DateOccupation, (int)occupation.IdPaciente, (int)occupation.State);
                return Ok(updatedOccupation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{OccupationId}")]
        public async Task<IActionResult> DeleteOccupation(int OccupationId)
        {
            try
            {
                await _occupationService.DeleteOccupation(OccupationId,false);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
