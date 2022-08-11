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
        private SqlDepartmentService _departmentService;

        public DepartmentsController(ILogger<DepartmentsController> logger, SqlDepartmentService service)
        {
            _logger = logger;
            _departmentService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> Get()
        {
            List<Department> departments = _departmentService.All();
            return Ok(departments);
        }
    }
}
