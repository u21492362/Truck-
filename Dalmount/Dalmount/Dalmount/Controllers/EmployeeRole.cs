using Microsoft.AspNetCore.Mvc;
using Dalmount.Models;
using Dalmount.View_Models;
using Dalmount.Context;

namespace Dalmount.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeRoleController : Controller
    {
        private readonly IRepository _repository;
        private readonly AppDbContext _appDbContext;

        public EmployeeRoleController(IRepository repository, AppDbContext appDbContext)
        {

            _repository = repository;
            _appDbContext = appDbContext;
        }

        // GET ALL EMPLOYEE ROLES
        [HttpGet]
        [Route("GetAllEmployeeRoles")]
        public async Task<IActionResult> GellAllEmployeeRoles()
        {
            try
            {
                var results = await _repository.GetAllEmployeeRolesAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
        }

        // CREATE EMPLOYEE ROLE
        /*[HttpPut]
        [Route("AddEmployeeRole")]
        public async Task<IActionResult<EmployeeRoleVM>>*/
    }
}
