using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poort80Assignment.Context;
using Poort80Assignment.Service;
using Poort80Assignment.Interfaces;
using Poort80Assignment.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Poort80Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ILogger<DepartmentsController> _logger;
        private ICRUDservice<Department, DepartmentIn> _departmentService;

        public DepartmentsController(ILogger<DepartmentsController> logger, ICRUDservice<Department, DepartmentIn> service)
        {
            _logger = logger;
            _departmentService = service;
        }

        [HttpGet]
        public ActionResult<List<Department>> Get()
        {
            List<Department> departments = _departmentService.All();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public ActionResult<Department> Get(int id)
        {
            Department? department = _departmentService.Find(id);
            return Ok(department);
        }

        [HttpPost]
        public ActionResult<Department> Post(DepartmentIn change)
        {
            Department? department = _departmentService.Create(change);
            return Ok(department);
        }

        [HttpPut("{id}")]
        public ActionResult<Department> Put(int id, DepartmentIn change)
        {
            Department? department = _departmentService.Find(id);
            if (department == null)
                return NotFound($"Couldn't find employee with {id}");
            return Ok(_departmentService.Update(change, department));
        }

        [HttpDelete("{id}")]
        public ActionResult<Department> Delete(int id)
        {
            Department? department = _departmentService.Find(id);
            if (department == null)
                return NotFound($"Couldn't find employee with {id}");
            _departmentService.Delete(department);
            return Ok("Success");
        }
    }
}
