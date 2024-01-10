using System.Collections.Generic;
using System.Reflection.Emit;
using Dalmount.Models;
using Microsoft.EntityFrameworkCore;

namespace Dalmount.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		public DbSet<UserVM> Users { get; set; }
		public DbSet<Truck_Miles> Miles { get; set; }
		//protected override void OnModelCreating(ModelBuilder builder)
		//{
		//	builder.Entity<User>().ToTable("user");
		//}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<EmployeeRole> EmployeeRoles { get; set; }
		public DbSet<Gender> Genders { get; set; }
		public DbSet<Salary> Salaries{ get; set; }

	}
}
