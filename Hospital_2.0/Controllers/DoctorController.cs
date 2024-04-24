using Hospital_2._0.Models;
using Hospital_2._0.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> GetAllDoctor()
        {
            return Ok(await _doctorService.GetAll());

        }

        [HttpGet("{DoctorId}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int DoctorId)
        {
            var Patient = await _doctorService.GetDoctor(DoctorId);
            if (Patient == null)
            {
                return BadRequest("User No Fount");
            }
            return Ok(Patient);

        }

    }
}
