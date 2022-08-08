using Microsoft.AspNetCore.Mvc;
using Poort80Assignment.Interfaces;
using Poort80Assignment.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Poort80Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly ILogger<EmployeesController> _logger;
        private IEployeeData _employeeData;

        public EmployeesController(ILogger<EmployeesController> logger, IEployeeData employeeData)
        {
            _logger = logger;
            _employeeData = employeeData;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_employeeData.GetEmployees());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Employee employee = _employeeData.GetEmployee(id);
            if (employee == null)
                return NotFound($"Employee with Id: {id} was not found");
            return Ok(employee);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Employee value)
        {
            _employeeData.AddEmployee(value);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + value.Id, value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Employee value)
        {
            Employee employee = _employeeData.GetEmployee(id);
            if (employee == null)
                return NotFound($"Employee with Id: {id} was not found");
            value.Id = employee.Id;
            value = _employeeData.EditEmployee(value);
            return Ok(value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Employee employee = _employeeData.GetEmployee(id);
            if (employee == null)
                return NotFound($"Employee with Id: {id} was not found");
            _employeeData.DeleteEmplyee(employee);
            return Ok();
        }
    }
}
