using HotDesks.DTOs;
using HotDesks.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotDesks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeDTO employeeDto)
        {
            _employeeService.AddEmployee(employeeDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeDTO employeeDto)
        {
            _employeeService.UpdateEmployee(id, employeeDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveEmployee(int id)
        {
            _employeeService.RemoveEmployee(id);
            return Ok();
        }
    }

}
