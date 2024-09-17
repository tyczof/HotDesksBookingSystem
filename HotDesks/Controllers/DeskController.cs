using HotDesks.DTOs;
using HotDesks.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAvailableDesks(DateTime startDate, DateTime endDate, int locationId = 0)
        {
            try
            {
                var desks = _deskService.GetAvailableDesks(startDate, endDate, locationId);

                // Return OK (200) with the available desks
                return Ok(desks);
            }
            catch (Exception ex)
            {
                // In case of an error, return a BadRequest (400) with the error message
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
        [HttpPut("disabledesk/{id}")]
        public IActionResult DisableDesk(int id)
        {
            _deskService.DisableDesk(id);
            return Ok();
        }
    }

}
