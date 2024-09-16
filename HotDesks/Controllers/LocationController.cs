using HotDesks.DTOs;
using HotDesks.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotDesks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public IActionResult GetLocations()
        {
            return Ok(_locationService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetLocation(int id)
        {
            var location = _locationService.GetById(id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        [HttpPost]
        public IActionResult AddLocation([FromBody] LocationDTO locationDto)
        {
            _locationService.AddLocation(locationDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLocation(int id, [FromBody] LocationDTO locationDto)
        {
            _locationService.UpdateLocation(id, locationDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveLocation(int id)
        {
            try
            {
                _locationService.RemoveLocation(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
