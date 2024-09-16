using HotDesks.DTOs;
using HotDesks.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotDesks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public IActionResult GetReservations()
        {
            return Ok(_reservationService.GetAll());
        }

        [HttpPost]
        public IActionResult AddReservation([FromBody] ReservationDTO reservationDto)
        {
            _reservationService.AddReservation(reservationDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult CancelReservation(int id)
        {
            _reservationService.CancelReservation(id);
            return Ok();
        }
    }

}
