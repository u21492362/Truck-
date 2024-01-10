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

		// GENDER
		public async Task<Gender[]> GetAllGendersAsync()
		{
			IQueryable<Gender> query = _appDbContext.Genders;
			return await query.ToArrayAsync();
		}

		public async Task<Gender> GetGenderByIdAsync(int genderId)
		{
			IQueryable<Gender> query = _appDbContext.Genders.Where(g => g.GenderId == genderId);
			return await query.FirstOrDefaultAsync();
		}

        // SALARY
        public async Task<Salary[]> GetAllSalariesAsync()
        {
            IQueryable<Salary> query = _appDbContext.Salaries;
            return await query.ToArrayAsync();
        }

        // EMPLOYEE ROLE
        public async Task<EmployeeRole[]> GetAllEmployeeRolesAsync()
        {
            IQueryable<EmployeeRole> query = _appDbContext.EmployeeRoles;
            return await query.ToArrayAsync();
        }

        public async Task<EmployeeRole> GetEmployeeRoleByIdAsync(int employeeRoleId)
        {
            IQueryable<EmployeeRole> query = _appDbContext.EmployeeRoles.Where(g => g.EmployeeRoleId == employeeRoleId);
            return await query.FirstOrDefaultAsync();
        }

        // EMPLOYEE

        public async Task<Employee[]> GetAllEmployeeSAsync()
        {
            IQueryable<Employee> query = _appDbContext.Employees.Include(e => e.Gender).Include(e => e.EmployeeRole).Include(e => e.Salary);
            return await query.ToArrayAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            IQueryable<Employee> query = _appDbContext.Employees.Where(e => e.EmployeeId == employeeId);
            return await query.FirstOrDefaultAsync();
        }

    }
}
