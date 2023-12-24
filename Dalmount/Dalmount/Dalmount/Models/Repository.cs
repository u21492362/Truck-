using Dalmount.Context;
using Microsoft.EntityFrameworkCore;

namespace Dalmount.Models
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
		public async Task<UserVM[]> ViewProfileAsync()
		{
			IQueryable<UserVM> query = _appDbContext.Users;
			return await query.ToArrayAsync();
		}

		public async Task<Truck_Miles[]> GetAllTruck_MilesAsync()
		{
			IQueryable<Truck_Miles> query = _appDbContext.Miles;
			return await query.ToArrayAsync();
		}

	}
}
