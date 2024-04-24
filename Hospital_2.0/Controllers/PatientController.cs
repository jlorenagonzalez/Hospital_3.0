using Hospital_2._0.Models;
using Hospital_2._0.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Patient>>> GetAllPatient()
        {
            return Ok(await _patientService.GetAll());

        }

        [HttpGet("{PatientId}")]
        public async Task<ActionResult<Patient>> GetPatient(int PatientId)
        {
            var Patient = await _patientService.GetPatient(PatientId);
            if (Patient == null)
            {
                return BadRequest("User No Fount");
            }
            return Ok(Patient);

        }

        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            try
            {
                var createdPatient = await _patientService.CreatePatient(patient.Firt_Name, patient.Second_Name, patient.First_last_name, patient.Second_Name, (DateTime)patient.Birth_date, (int)patient.Age, patient.Gender, patient.Address, (int)patient.Telephone_Number, patient.Mail, (int)patient.Clinic_History, (int)patient.ID_Doctor);
                return CreatedAtAction(nameof(GetPatient), new { PatientId = createdPatient.PatientId }, createdPatient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{PatientId}")]
        public async Task<IActionResult> PutPatient(int PatientId, Patient patient)
        {
            if (PatientId != patient.PatientId)
            {
                return BadRequest();
            }

            try
            {
                var updatedPatient = await _patientService.UpdatePatient(PatientId, patient.Firt_Name, patient.Second_Name, patient.First_last_name, patient.Second_Name, (DateTime)patient.Birth_date, (int)patient.Age, patient.Gender, patient.Address, (int)patient.Telephone_Number, patient.Mail, (int)patient.Clinic_History, (int)patient.ID_Doctor);
                return Ok(updatedPatient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{PatientId}")]
        public async Task<IActionResult> DeletePatient(int PatientId)
        {
            try
            {
                await _patientService.DeletePatient(PatientId, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }




    }


}
