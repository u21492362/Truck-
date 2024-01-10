using System.ComponentModel.DataAnnotations;

namespace Dalmount.Models
{
    public class Salary
    {
        [Key]
        public int SalaryId { get; set; }
        public int Amount { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }

    }
}
