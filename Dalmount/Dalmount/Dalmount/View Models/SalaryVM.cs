using System.ComponentModel.DataAnnotations;

namespace Dalmount.View_Models
{
    public class SalaryVM
    {
        [Key]
        public int SalaryId { get; set; }
        public int Amount { get; set; }
    }
}
}
