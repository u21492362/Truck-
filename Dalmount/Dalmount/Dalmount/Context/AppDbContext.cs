using System.Collections.Generic;
using System.Reflection.Emit;
using T_Dalmount.Models;
using Microsoft.EntityFrameworkCore;

namespace T_Dalmount.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		public DbSet<User> Users { get; set; }
		public DbSet<Truck_Miles> Miles { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<User>().ToTable("users");
		}
	}
}
