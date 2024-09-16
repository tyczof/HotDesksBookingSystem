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
            return Ok(_deskService.GetAll());
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
            _deskService.RemoveDesk(id);
            return Ok();
        }
    }

}
