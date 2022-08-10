using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poort80Assignment.Context;
using Poort80Assignment.Interfaces;
using Poort80Assignment.Models;
using Poort80Assignment.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Poort80Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly ILogger<EmployeesController> _logger;
        private SqlEmployeeService _employeeService;
        private SqlDepartmentService _departmentService;

        public EmployeesController(ILogger<EmployeesController> logger, SqlEmployeeService employeeService, SqlDepartmentService departmentService)
        {
            _logger = logger;
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeWithDepartment>> Get(int id)
        {
            Employee? employee = _employeeService.Find(id);
            EmployeeWithDepartment employeeWithDepartment = new()
            {
                Id = employee.Id,
                Name = employee.Name,
                DepartmentId = employee.DepartmentId,
                Department = _departmentService.Find(id)
            };
            return Ok(employeeWithDepartment);
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            List<Employee> employees = _employeeService.All();
            return Ok(employees);
        }
    }
}
