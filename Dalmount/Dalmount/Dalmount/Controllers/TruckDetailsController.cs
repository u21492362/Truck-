using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dalmount.Context;
using Dalmount.Models;

namespace Dalmount.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class TruckDetailsController : Controller
	{
		private readonly AppDbContext _context;

		public TruckDetailsController(AppDbContext context)
		{
			_context = context;
		}

		[HttpPost("start-shift")]
		public async Task<IActionResult> StartShift(int startMileage)
		{
			try
			{
				var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
				if (string.IsNullOrEmpty(userId))
				{
					return BadRequest("User ID not found in claims.");
				}

				var driver = await _context.Users.FindAsync(Convert.ToInt32(userId));
				if (driver == null)
				{
					return NotFound("Driver not found.");
				}

				var existingShift = await _context.Miles
					.Where(s => s.DriverId == driver.Id && s.EndTime == null)
					.FirstOrDefaultAsync();

				if (existingShift != null)
				{
					return BadRequest("Driver already has an active shift.");
				}

				var newShift = new Truck_Miles
				{
					StartTime = DateTime.UtcNow,
					StartMileage = startMileage,
					DriverId = driver.Id
				};

				_context.Miles.Add(newShift);
				await _context.SaveChangesAsync();

				return Ok("Shift started successfully.");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal Server Error: {ex.Message}");
			}
		}

		[HttpPost("end-shift")]
		public async Task<IActionResult> EndShift(int endMileage)
		{
			try
			{
				var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
				if (string.IsNullOrEmpty(userId))
				{
					return BadRequest("User ID not found in claims.");
				}

				var driver = await _context.Users.FindAsync(Convert.ToInt32(userId));
				if (driver == null)
				{
					return NotFound("Driver not found.");
				}

				var activeShift = await _context.Miles
					.Where(s => s.DriverId == driver.Id && s.EndTime == null)
					.FirstOrDefaultAsync();

				if (activeShift == null)
				{
					return BadRequest("No active shift found for the driver.");
				}

				activeShift.EndTime = DateTime.UtcNow;
				activeShift.EndMileage = endMileage;

				await _context.SaveChangesAsync();

				return Ok("Shift ended successfully.");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal Server Error: {ex.Message}");
			}
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("get-shifts")]
		public IActionResult GetShifts()
		{
			try
			{
				var shifts = _context.Miles
					.Include(s => s.Driver)
					.OrderByDescending(s => s.StartTime)
					.ToList();

				return Ok(shifts);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal Server Error: {ex.Message}");
			}
		}
	}
}

