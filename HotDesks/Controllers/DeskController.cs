using HotDesks.DTOs;
using HotDesks.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace HotDesks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeskController : ControllerBase
    {
        private readonly IDeskService _deskService;

        public DeskController(IDeskService deskService)
        {
            _deskService = deskService;
        }

        [HttpGet]
        public IActionResult GetDesks()
        {
            var desks = _deskService.GetAll();
            return desks.Any() ? Ok(desks) : NotFound();
        }
        [HttpGet("available")]
        public IActionResult GetDesksWithReservationStatus(DateTime startDate, DateTime endDate, int locationId = 0)
        {
            try
            {
                var desks = _deskService.GetDesksWithReservationStatus(startDate, endDate, locationId);

                return Ok(desks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddDesk([FromBody] DeskDTO deskDto)
        {
            _deskService.AddDesk(deskDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDesk(int id, [FromBody] DeskDTO deskDto)
        {
            _deskService.UpdateDesk(id, deskDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveDesk(int id)
        {
            try
            {
                _deskService.RemoveDesk(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("changeavailability/{id}")]
        public IActionResult ToggleDeskAvailability(int id)
        {
            _deskService.ToggleDeskAvailability(id);
            return Ok();
        }
    }

}
