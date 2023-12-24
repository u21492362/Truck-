using T_Dalmount.Context;
using System.Threading.Tasks;
using T_Dalmount.Models;
using T_Dalmount.Controllers;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore;

namespace T_Dalmount.Models
{
	public class Repository : IRepository
	{
		private readonly AppDbContext _appDbContext;

		public Repository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;

		}

		public async Task<bool> SaveChangesAsync()
		{
			return await _appDbContext.SaveChangesAsync() > 0;
		}
		//public void Add<T>(T entity) where T : class
		//{
		//	_appDbContext.Add(entity);
		//}

		public void Add<T>(T entity) where T : class
		{
			_appDbContext.Add(entity);
		}

		public void Delete<T>(T entity) where T : class
		{
			_appDbContext.Remove(entity);
		}

		public void Update<T>(T entity) where T : class
		{
			_appDbContext.Update(entity);
		}
		// User
		public async Task<User[]> ViewProfileAsync()
		{
			IQueryable<User> query = _appDbContext.Users;
			return await query.ToArrayAsync();
		}

		public async Task<Truck_Miles[]> GetAllTruck_MilesAsync()
		{
			IQueryable<Truck_Miles> query = _appDbContext.Miles;
			return await query.ToArrayAsync();
		}

	}
}
