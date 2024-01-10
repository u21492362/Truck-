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

		Task<Gender[]> GetAllGendersAsync();
		Task<Gender> GetGenderByIdAsync(int genderId);
		Task<Salary[]> GetAllSalariesAsync();
		Task<Salary> GetSalaryByIdAsync(int salaryId);
		Task<EmployeeRole[]> GetAllEmployeeRolesAsync();
        Task<EmployeeRole> GetEmployeeRoleByIdAsync(int employeeRoleId);
		Task<Employee[]> GetAllEmployeesAsync();
		Task<Employee> GetEmployeeByIdAsync(int employeeId);

	}
}
