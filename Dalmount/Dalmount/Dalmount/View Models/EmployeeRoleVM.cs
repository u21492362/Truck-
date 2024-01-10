using System.ComponentModel.DataAnnotations;

namespace Dalmount.View_Models
{
    public class EmployeeRole
    {
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
