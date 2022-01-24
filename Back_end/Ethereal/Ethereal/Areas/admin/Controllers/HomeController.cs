using Ethereal.Data;
using Ethereal.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Ethereal.Areas.admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            

            VmHome model = new VmHome();
            model.Setting = _context.Settings.FirstOrDefault();
            return View(model);
        }
    }
}
