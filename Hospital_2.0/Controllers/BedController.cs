using Hospital_2._0.Models;
using Hospital_2._0.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedController : ControllerBase
    {

        private readonly IBedService _bedService;

        public BedController(IBedService bedService)
        {
            _bedService = bedService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Bed>>> GetAllBed()
        {
            return Ok(await _bedService.GetAll());

        }

        [HttpGet("{BedId}")]
        public async Task<ActionResult<Bed>> GetOccupation(int BedId)
        {
            var Bed = await _bedService.GetBed(BedId);
            if (Bed == null)
            {
                return BadRequest("User No Fount");
            }
            return Ok(Bed);

        }

    }
}
