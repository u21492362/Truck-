using System.ComponentModel.DataAnnotations;

namespace Dalmount.View_Models
{
    public class GenderVM
    {
        [Key]
        public int GenderId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
