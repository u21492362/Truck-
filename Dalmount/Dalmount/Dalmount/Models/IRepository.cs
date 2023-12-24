using T_Dalmount.Context;
using System.Threading.Tasks;
using T_Dalmount.Models;
using T_Dalmount.Controllers;

namespace T_Dalmount.Models
{
	public interface IRepository
	{ 
		void Add<T>(T entity) where T : class;
		void Delete<T>(T entity) where T : class;
		void Update<T>(T entity) where T : class;
		Task<bool> SaveChangesAsync();
		Task<User[]> ViewProfileAsync();

		Task<Truck_Miles[]> GetAllTruck_MilesAsync();

	}
}
