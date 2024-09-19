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
        [HttpGet("employee/{employeeId}")]
        public IActionResult GetEmployeeReservations(int employeeId)
        {
            return Ok(_reservationService.GetEmployeeReservations(employeeId));
        }

        [HttpPost]
        public IActionResult AddReservation([FromBody] ReservationDTO reservationDto)
        {
            try
            {
                _reservationService.AddReservation(reservationDto);
                return Ok(reservationDto);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateReservation(int id, [FromBody] ReservationDTO reservationDto)
        {
            try
            {
                _reservationService.UpdateReservation(id, reservationDto);
                return Ok(reservationDto);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("cancel/{id}")]
        public IActionResult CancelReservation(int id)
        {
            try
            {
                _reservationService.CancelReservation(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
