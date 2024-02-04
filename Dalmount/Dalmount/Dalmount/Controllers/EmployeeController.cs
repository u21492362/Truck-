﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Dalmount.Models;
using Dalmount.View_Models;
using Dalmount.Context;
using System.Threading.Tasks;

namespace Dalmount.Controllers
{
    [Route("api/[Controller]")]
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

                    EmployeeRoleName = e.EmployeeRole.Name,

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

        // CREATE EMPLOYEE
        [HttpPut]
        [Route("AddEmployee")]
        public async Task<ActionResult<EmployeeVM>> AddEmployee(EmployeeVM evm)
        {
            var employee = new Employee

            {
                Surname = evm.Surname,
                FirstName = evm.FirstName,
                Email_Address = evm.Email_Address,
                Physical_Address = evm.Physical_Address,
                PhoneNumber = evm.PhoneNumber,
                Employment_Date = evm.Employment_Date,
                SalaryId = Convert.ToInt32(evm.Salary),
                EmployeeRoleId = Convert.ToInt32(evm.EmployeeRole),
                GenderId = Convert.ToInt32(evm.Gender),
            };

            try
            {
                _repository.Add(employee);
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                // fix error message
                return BadRequest("Invalid Transaction");
            }

            return Ok(employee);

        }

        // GET EMPLOYEE BY ID
        [HttpGet]
        [Route("GetEmployee/{employeeId}")]
        public async Task<IActionResult> GetEmployeeByIdAsync(int employeeId)
        {
            try
            {
                var result = await _repository.GetEmployeeByIdAsync(employeeId);

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
        public async Task<ActionResult<EmployeeVM>> UpdateEmployee(int employeeId, EmployeeVM evm)
        {
            try
            {
                var currentEmployee = await _repository.GetEmployeeByIdAsync(employeeId);
                if (currentEmployee == null) return NotFound($"The employee does not exist");

                currentEmployee.Surname = evm.Surname;
                currentEmployee.FirstName = evm.FirstName;
                currentEmployee.Email_Address = evm.Email_Address; 
                currentEmployee.Physical_Address = evm.Physical_Address;
                currentEmployee.PhoneNumber = evm.PhoneNumber;
                currentEmployee.Employment_Date = evm.Employment_Date;
                currentEmployee.EmployeeRoleId = Convert.ToInt32(evm.EmployeeRole);
                currentEmployee.GenderId = Convert.ToInt32(evm.Gender);
                currentEmployee.SalaryId = Convert.ToInt32(evm.Salary);

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
                var currentEmployee = await _repository.GetEmployeeByIdAsync(employeeId);

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
