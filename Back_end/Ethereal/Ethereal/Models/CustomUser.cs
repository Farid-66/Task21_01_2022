using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ethereal.Models
{
    public class CustomUser:IdentityUser
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Surname { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Testimonials> Testimonials { get; set; }
    }
}
