using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ethereal.Models
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string BrandName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        [MaxLength(350)]
        public string Address { get; set; }

        [Column(TypeName ="ntext")]
        public string About { get; set; }
    }
}
