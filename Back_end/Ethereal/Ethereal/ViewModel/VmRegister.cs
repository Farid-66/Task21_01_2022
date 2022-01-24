using System.ComponentModel.DataAnnotations;

namespace Ethereal.ViewModel
{
    public class VmRegister
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(60)]
        public string Surname { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(30)]
        public string Password { get; set; }

        [MaxLength(40)]
        public string Phone { get; set; }
    }
}
