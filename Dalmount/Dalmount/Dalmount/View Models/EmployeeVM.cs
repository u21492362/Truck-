using Dalmount.View_Models;
using System.ComponentModel.DataAnnotations;

namespace Dalmount.View_Models
{
    public class EmployeeVM
    {
        public class Employee
        {
            public int EmployeeId { get; set; }
            public string FirstName { get; set; }
            public string Surname { get; set; }
            public string Email_Address { get; set; }
            public string PhoneNumber { get; set; }
            public string Physical_Address { get; set; }

            public int EmployeeRole { get; set; }
            public int Salary { get; set; }
            public int Gender { get; set; }
            public DateTime Employment_Date { get; set; }

        }
    }
}
