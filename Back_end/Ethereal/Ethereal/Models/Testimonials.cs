using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ethereal.Models
{
    public class Testimonials
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Content { get; set; }

        [ForeignKey("CustomUser")]
        public string CustomUserId { get; set; }
        public CustomUser CustomUser { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
