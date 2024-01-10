using System.ComponentModel.DataAnnotations;

namespace Dalmount.Models
{
    public class EmployeeRole
    {
        [Key]

        public int EmployeeRoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
    }
}
