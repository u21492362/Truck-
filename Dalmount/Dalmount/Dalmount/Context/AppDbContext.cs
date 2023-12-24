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
	}
}
