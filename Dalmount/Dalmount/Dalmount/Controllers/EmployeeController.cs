using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Dalmount.Models;
using Dalmount.View_Models;
using Dalmount.Context;

namespace Dalmount.Controllers
{
    [Route("api/[Controller")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IRepository _repository;
        private readonly AppDbContext _appDbContext;

        public EmployeeController(IRepository repository, AppDbContext appDbContext)
        {

            _repository = repository;
            _appDbContext = appDbContext;
        }

        // GET ALL EMPLOYEES
        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var results = await _repository.GetAllEmployeesAsync();

                dynamic employees = results.Select(e => new
                {
                    e.EmployeeId,

                    e.Surname,

                    e.FirstName,

                    EmployeeRoleName = e.Employee_Role.Name,

                    e.PhoneNumber,

                    e.Email_Address,

                    e.Physical_Address,

                    e.Employment_Date,

                    GenderName = e.Gender.Name,
                });

                return Ok(employees);
            }

            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
        }

        // GET EMPLOYEE BY ID

        [HttpGet]
        [Route("GetEmployee/{employeeId}")]
        public async Task<IActionResult> GetEmployeeAsync(int employeeId)
        {
            try
            {
                var result = await _repository.GetEmployeeAsync(employeeId);

                if (result == null) return NotFound("Employee does not exist. You need to create an employee first");

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support");
            }
        }

        // UPDATE EMPLOYEE

        [HttpPut]
        [Route("EditEmployee/{employeeId}")]
        public async Task<ActionResult<EmployeeVM>> EditSupplier(int employeeId, EmployeeVM svm)
        {
            try
            {
                var currentEmployee = await _repository.GetEmployeeAsync(employeeId);
                if (currentEmployee == null) return NotFound($"The supplier does not exist");

                currentEmployee.Surname = svm.Surname;
                currentEmployee.FirstName = svm.FirstName;
                currentEmployee.Email_Address = svm.Email_Address;
                currentEmployee.Employee_RoleId = Convert.ToInt32(svm.EmployeeRole);
                currentEmployee.GenderId = Convert.ToInt32(svm.Gender);
                currentEmployee.PhoneNumber = svm.PhoneNumber;
                currentEmployee.Physical_Address = svm.Physical_Address;

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(currentEmployee);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
            return BadRequest("Your request is invalid.");
        }

        // DELETE EMPLOYEE

        [HttpDelete]
        [Route("DeleteEmployee/{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            try
            {
                var currentEmployee = await _repository.GetEmployeeAsync(employeeId);

                if (currentEmployee == null) return NotFound($"The employee does not exist");

                _repository.Delete(currentEmployee);

                if (await _repository.SaveChangesAsync()) return Ok(currentEmployee);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
            return BadRequest("Your request is invalid.");
        }

        // GET ALL GENDERS

        [HttpGet]
        [Route("GetAllGenders")]
        public async Task<IActionResult> GetAllGenders()
        {
            try
            {
                var results = await _repository.GetAllGendersAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
        }
    }
}
