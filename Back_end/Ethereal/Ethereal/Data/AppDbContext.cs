using Ethereal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ethereal.Data
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions options):base(options) 
        {

        }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
        public DbSet<CustomUser> CustomUsers { get; set; }
    }
}
