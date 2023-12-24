namespace Dalmount.Models
{
	public interface IRepository
	{ 
		void Add<T>(T entity) where T : class;
		void Delete<T>(T entity) where T : class;
		void Update<T>(T entity) where T : class;
		Task<bool> SaveChangesAsync();
		Task<UserVM[]> ViewProfileAsync();

		Task<Truck_Miles[]> GetAllTruck_MilesAsync();

	}
}
