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
        private ICRUDservice<Employee, EmployeeIn> _employeeService;
        private ICRUDservice<Department, DepartmentIn> _departmentService;

        public EmployeesController(ILogger<EmployeesController> logger, ICRUDservice<Employee, EmployeeIn> employeeService, ICRUDservice<Department, DepartmentIn> departmentService)
        {
            _logger = logger;
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            List<Employee> employees = _employeeService.All();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeWithDepartment> Get(int id)
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

        [HttpPost]
        public ActionResult<Employee> Post(EmployeeIn change)
        {
            Employee? employee = _employeeService.Create(change);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, EmployeeIn change)
        {
            Employee? employee = _employeeService.Find(id);
            if (employee == null)
                return NotFound($"Couldn't find employee with {id}");
            return Ok(_employeeService.Update(change, employee));
        }

        [HttpDelete("{id}")]
        public ActionResult<Employee> Delete(int id)
        {
            Employee? employee = _employeeService.Find(id);
            if (employee == null)
                return NotFound($"Couldn't find employee with {id}");
            _employeeService.Delete(employee);
            return Ok("Success");
        }
    }
}
