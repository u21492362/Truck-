namespace Dalmount.Models
{
	public class Truck_Miles
	{
		public int Id { get; set; }
		public int DriverId { get; set; }
		public User Driver { get; set; }
		public int StartMileage { get; set; }
		public int? EndMileage { get; set; }
		public DateTime? StartTime { get; set; }
		public DateTime? EndTime { get; set; }
		public string? Feedback { get; set; }

	}
}
