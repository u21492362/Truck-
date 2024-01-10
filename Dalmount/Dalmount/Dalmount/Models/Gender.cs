using System.ComponentModel.DataAnnotations;

namespace Dalmount.Models
{
    public class Gender
    {
        [Key]

        public int GenderId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Gender> Genders { get; set; }
    }
}
