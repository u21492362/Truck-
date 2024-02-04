using Dalmount.View_Models;
using System.ComponentModel.DataAnnotations;

namespace Dalmount.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Surname { get; set; } = string.Empty.ToString();
        public string FirstName { get; set; } = string.Empty.ToString();
        public string? Email_Address { get; set; }
        public string? Physical_Address { get; set; } = string.Empty.ToString();
        public string PhoneNumber { get; set; } = string.Empty.ToString();
        public DateTime Employment_Date { get; set; }
        public int Salary { get; set; }
        public int EmployeeRoleId { get; set; }
        public int GenderId { get; set; }
        public EmployeeRole EmployeeRole { get; set; }
        public Gender Gender { get; set; }
    }
}
