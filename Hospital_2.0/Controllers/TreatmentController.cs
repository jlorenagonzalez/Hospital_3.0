using Hospital_2._0.Models;
using Hospital_2._0.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentService _itreatmentService;

        public TreatmentController(ITreatmentService treatmentService)
        {
            _itreatmentService = treatmentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Treatment>>> GetAllTreatment()
        {
            return Ok(await _itreatmentService.GetAll());

        }

        [HttpGet("{TreatmentId}")]
        public async Task<ActionResult<Treatment>> GetTreatment(int TreatmentId)
        {
            var Treatment = await _itreatmentService.GetTreatment(TreatmentId);
            if (Treatment == null)
            {
                return BadRequest("User No Fount");
            }
            return Ok(Treatment);

        }

        [HttpPost]
        public async Task<ActionResult<Treatment>> PostTreatment(Treatment treatment)
        {
            try
            {
                var createdTreatment = await _itreatmentService.CreateTreatment(treatment.PatientId, treatment.DoctorId, (DateTime)treatment.StartDate, (DateTime)treatment.EndDate, treatment.Description);
                return CreatedAtAction(nameof(GetTreatment), new { TreatmentId = createdTreatment.TreatmentId }, createdTreatment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{TreatmentId}")]
        public async Task<IActionResult> PutTreatment(int TreatmentId, Treatment treatment)
        {
            if (TreatmentId != treatment.TreatmentId)
            {
                return BadRequest();
            }

            try
            {
                var updatedTreatment = await _itreatmentService.UpdateTreatment(TreatmentId, treatment.PatientId, treatment.DoctorId, treatment.StartDate, treatment.EndDate, treatment.Description);
                return Ok(updatedTreatment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{TreatmentId}")]
        public async Task<IActionResult> DeleteTreatment(int TreatmentId)
        {
            try
            {
                await _itreatmentService.DeleteTreatment(TreatmentId, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }




    }
}
